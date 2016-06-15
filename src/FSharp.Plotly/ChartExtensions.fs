﻿namespace FSharp.Plotly

open System
open System.IO

open GenericChart

/// Extensions methods for Charts supporting the fluent pipeline style 'Chart.WithXYZ(...)'.
[<AutoOpen>]
module ChartExtensions =
    
    /// Provides a set of static methods for creating charts.
    type Chart with   
        
        // ####################### Apply to trace

        /// Set the name related properties of a trace
        static member withTraceName(?Name,?Showlegend,?Legendgroup,?Visible) =
            (fun (ch:GenericChart) ->                   
                ch |> mapiTrace (fun i trace -> 
                                   match trace with
                                   | :? ITraceInfo as traceinfo ->
                                            let naming i name = name |> Option.map (fun v -> if i = 0 then v else sprintf "%s_%i" v i)                                   
                                            traceinfo 
                                            |> Options.ITraceInfo(?Name=(naming i Name),?Showlegend=Showlegend,?Legendgroup=Legendgroup,?Visible=Visible)
                                            :?> ITrace
                                   | _ -> trace 
                                 )
            )
//
//        /// Set the name related properties of a trace
//        // TODO
//        static member withTraceInfo(?textinfo,?textinfoposition,?hoverinfo) =
//            (fun (ch:GenericChart) ->                   
//                ch |> mapiTrace (fun i trace -> 
//                                   trace) // |> Helpers.ApplyTraceStyles())          
//            )
        
//        /// Apply styling to the Marker(s) of the chart as Object.
//        static member withMarkerOption(marker:Marker) =
//            (fun (ch:GenericChart) ->                                    
//                ch 
//                |> mapTrace (fun trace ->
//                    match box trace with   
//                    | :? Trace as t when t:(member Walk : unit -> unit) -> t
//                    | t -> trace
//                            )
//            )
               
//        /// Apply styling to the Marker(s) of the chart.
//        static member withMarkerStyle(?Size,?Color,?Symbol,?Opacity) = 
//            let marker = 
//                Marker()                
//                |> Helpers.ApplyMarkerStyles(?size=Size,?color=Color,?symbol=Symbol,?opacity=Opacity)
//            
//            Chart.withMarkerOption(marker)         
            
        /// Apply styling to the Line(s) of the chart as Object.
        static member withLineOption(line:LineOptions) =
            (fun (ch:GenericChart) ->                   
                ch |> mapTrace (fun trace ->                                     
                                    match trace with
                                    | :? ILine as lineTrace -> 
                                        lineTrace
                                        |> Options.ILine(line)  :?> ITrace 
                                    | _        -> trace 
                               )
            )
               
        /// Apply styling to the Line(s) of the chart.
        static member withLineStyle(?Width,?Color,?Shape,?Dash,?Smoothing,?ColorScale) =
            let line = Options.Line(?Width=Width,?Color=Color,?Shape=Shape,?Dash=Dash,?Smoothing=Smoothing,?ColorScale=ColorScale)            
            Chart.withLineOption(line)  


//
        // ####################### Apply to layout
        static member withX_Axis(xAxis:AxisOptions) =       
            (fun (ch:GenericChart) ->                 
                let layout = 
                    Options.Layout(xAxis=xAxis)
                GenericChart.addLayout layout ch)             
        
        static member withX_AxisStyle(title,?MinMax) =       
            (fun (ch:GenericChart) ->                 
                let range = if MinMax.IsSome then Some (StyleOption.RangeValues.MinMax (MinMax.Value)) else None
                let xaxis = Options.Axis(Title=title,?Range=range)
                let layout = Options.Layout(xAxis=xaxis)
                GenericChart.addLayout layout ch)     


        static member withY_Axis(yAxis:AxisOptions) =       
            (fun (ch:GenericChart) ->                 
                let layout = 
                    Options.Layout(yAxis=yAxis)
                GenericChart.addLayout layout ch)  

        static member withY_AxisStyle(title,?MinMax) =
            (fun (ch:GenericChart) ->                 
                let range = if MinMax.IsSome then Some (StyleOption.RangeValues.MinMax (MinMax.Value)) else None
                let yaxis = Options.Axis(Title=title,?Range=range)
                let layout = Options.Layout(yAxis=yaxis)
                GenericChart.addLayout layout ch)                 


        static member withLayout(layout:LayoutOptions) =
            (fun (ch:GenericChart) -> 
                GenericChart.addLayout layout ch)         

        static member withSize(width,heigth) =            
            (fun (ch:GenericChart) -> 
                let layout = Options.Layout(Width=width,Height=heigth)
                GenericChart.addLayout layout ch)  

        static member withMargin(margin:MarginOptions) =        
            (fun (ch:GenericChart) ->                 
                let layout = Options.Layout(Margin=margin)
                GenericChart.addLayout layout ch)   

        static member withMarginSize(?Left,?Right,?Top,?Bottom,?Pad,?Autoexpand) =                       
                let margin = Options.Margin(?Left=Left,?Right=Right,?Top=Top,?Bottom=Bottom,?Pad=Pad,?Autoexpand=Autoexpand)
                Chart.withMargin(margin) 

                



//        // with Layout
//        static member withError(layout:Layout) =
//            (fun (ch:GenericChart) -> 
//                GenericChart.setLayout layout ch)   



        // ####################### 
        /// Create a combined chart with the given charts merged   
        static member Combine(gCharts:seq<GenericChart>) =
            GenericChart.combine gCharts
        
        /// Show chart in browser            
        static member Show (ch:GenericChart) = 
            let guid = Guid.NewGuid().ToString()
            let html = GenericChart.toEmbeddedHTML ch
            let tempPath = Path.GetTempPath()
            let file = sprintf "%s.html" guid
            let path = Path.Combine(tempPath, file)
            File.WriteAllText(path, html)
            System.Diagnostics.Process.Start(path) |> ignore

