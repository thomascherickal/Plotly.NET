namespace Plotly.NET

open DynamicObj
open System

/// Trace type inherits from dynamic object
type Trace3d (traceTypeName) =
    inherit Trace (traceTypeName)


[<CompilationRepresentationAttribute(CompilationRepresentationFlags.ModuleSuffix)>]
module Trace3d = 
    //TO-DO: we need to think about if all subgroups of traces should be seperate, e.g. also "TraceFinance" or leave it at the current separation
    //-------------------------------------------------------------------------------------------------------------------------------------------------
    //3D

    ///initializes a trace of type "scatter3d" applying the givin trace styling function
    let initScatter3d (applyStyle:Trace3d->Trace3d) = 
        Trace3d("scatter3d") |> applyStyle

    ///initializes a trace of type "surface" applying the givin trace styling function
    let initSurface (applyStyle:Trace3d->Trace3d) = 
        Trace3d("surface") |> applyStyle

    ///initializes a trace of type "mesh3d" applying the givin trace styling function
    let initMesh3d (applyStyle:Trace3d->Trace3d) = 
        Trace3d("mesh3d") |> applyStyle

    ///initializes a trace of type "cone" applying the givin trace styling function
    let initCone (applyStyle:Trace3d->Trace3d) = 
        Trace3d("cone") |> applyStyle

    ///initializes a trace of type "streamtube" applying the givin trace styling function
    let initStreamTube (applyStyle:Trace3d->Trace3d) = 
        Trace3d("streamtube") |> applyStyle

    ///initializes a trace of type "volume" applying the givin trace styling function
    let initVolume (applyStyle:Trace3d->Trace3d) = 
        Trace3d("volume") |> applyStyle

    ///initializes a trace of type "isosurface" applying the givin trace styling function
    let initIsoSurface (applyStyle:Trace3d->Trace3d) = 
        Trace3d("isosurface") |> applyStyle


    //-------------------------------------------------------------------------------------------------------------------------------------------------
    /// Functions provide the styling of the Chart objects
    type Trace3dStyle() =

        // ######################## 3d-Charts
        
        static member setScene 
            (
                ?SceneName:string
            ) =
                fun (trace:Trace3d) ->
                    SceneName |> DynObj.setValueOpt trace "scene"
                    trace

        /// <summary>
        /// Applies the style parameters of the Scatter3d chart to the given trace
        /// </summary>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
        /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
        /// <param name="LegendGroupTitle">Sets the legend group title</param>
        /// <param name="Opacity">Sets the opacity of the trace.</param>
        /// <param name="Mode">Determines the drawing mode for this scatter trace. If the provided `mode` includes "text" then the `text` elements appear at the coordinates. Otherwise, the `text` elements appear on hover. If there are less than 20 points and the trace is not stacked then the default is "lines+markers". Otherwise, "lines".</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
        /// <param name="X">Sets the x coordinates.</param>
        /// <param name="Y">Sets the y coordinates.</param>
        /// <param name="Z">Sets the z coordinates.</param>
        /// <param name="SurfaceColor">Sets the surface fill color.</param>
        /// <param name="Text">Sets text elements associated with each (x,y,z) triplet. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y,z) coordinates. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="TextPosition">Sets the positions of the `text` elements with respects to the (x,y) coordinates.</param>
        /// <param name="TextTemplate">Template string used for rendering the information text that appear on points. Note that this will override `textinfo`. Variables are inserted using %{variable}, for example "y: %{y}". Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. Every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available.</param>
        /// <param name="HoverText">Sets text elements associated with each (x,y,z) triplet. If a single string, the same string appears over all the data points. If an array of string, the items are mapped in order to the this trace's (x,y,z) coordinates. To be seen, trace `hoverinfo` must contain a "text" flag.</param>
        /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
        /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
        /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
        /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `yaxis.hoverformat`.</param>
        /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `zaxis.hoverformat`.</param>
        /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
        /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
        /// <param name="Scene">Sets a reference between this trace's 3D coordinate system and a 3D scene. If "scene" (the default value), the (x,y,z) coordinates refer to `layout.scene`. If "scene2", the (x,y,z) coordinates refer to `layout.scene2`, and so on.</param>
        /// <param name="Marker">Sets the marker of this trace.</param>
        /// <param name="Line">Sets the line of this trace.</param>
        /// <param name="TextFont">Sets the text font of this trace.</param>
        /// <param name="ErrorX">Sets the x Error of this trace.</param>
        /// <param name="ErrorY">Sets the y Error of this trace.</param>
        /// <param name="ErrorZ">Sets the z Error of this trace.</param>
        /// <param name="ConnectGaps">Determines whether or not gaps (i.e. {nan} or missing values) in the provided data arrays are connected.</param>
        /// <param name="Hoverlabel">Sets the hoverlabel of this trace.</param>
        /// <param name="Projection">Sets the projection of this trace.</param>
        /// <param name="Surfaceaxis">If "-1", the scatter points are not fill with a surface If "0", "1", "2", the scatter points are filled with a Delaunay surface about the x, y, z respectively.</param>
        /// <param name="XCalendar">Sets the calendar system to use with `x` date data.</param>
        /// <param name="YCalendar">Sets the calendar system to use with `y` date data.</param>
        /// <param name="ZCalendar">Sets the calendar system to use with `z` date data.</param>
        /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
        static member Scatter3d
            (   
                ?Name               : string,
                ?Visible            : StyleParam.Visible,
                ?ShowLegend         : bool,
                ?LegendRank         : int,
                ?LegendGroup        : string,
                ?LegendGroupTitle   : Title,
                ?Mode               : StyleParam.Mode,
                ?Opacity            : float,
                ?Ids                : seq<#IConvertible>,
                ?X                  : seq<#IConvertible>,
                ?Y                  : seq<#IConvertible>,
                ?Z                  : seq<#IConvertible>,
                ?SurfaceColor       : string,
                ?Text               : seq<#IConvertible>,
                ?TextPosition       : StyleParam.TextPosition,
                ?TextTemplate       : string,
                ?HoverText          : seq<#IConvertible>,
                ?HoverInfo          : string,
                ?HoverTemplate      : string,
                ?XHoverFormat       : string,
                ?YHoverFormat       : string,
                ?ZHoverFormat       : string,
                ?Meta               : string,
                ?CustomData         : seq<#IConvertible>,
                ?Scene              : StyleParam.SubPlotId,
                ?Marker             : Marker,
                ?Line               : Line,
                ?TextFont           : Font,
                ?ErrorX             : Error,
                ?ErrorY             : Error,
                ?ErrorZ             : Error,
                ?ConnectGaps        : bool,
                ?Hoverlabel         : Hoverlabel,
                ?Projection         : Projection,
                ?Surfaceaxis        : StyleParam.SurfaceAxis,
                ?XCalendar          : StyleParam.Calendar,
                ?YCalendar          : StyleParam.Calendar,
                ?ZCalendar          : StyleParam.Calendar,
                ?UIRevision         : string
            ) =

                (fun (scatter: #Trace) ->
                
                    Name                |> DynObj.setValueOpt scatter "name"
                    Visible             |> DynObj.setValueOptBy scatter "visible" StyleParam.Visible.convert
                    ShowLegend          |> DynObj.setValueOpt scatter "showlegend"
                    LegendRank          |> DynObj.setValueOpt scatter "legendrank"
                    LegendGroup         |> DynObj.setValueOpt scatter "legendgroup"
                    LegendGroupTitle    |> DynObj.setValueOpt scatter "legendgrouptitle"
                    Mode                |> DynObj.setValueOptBy scatter "mode" StyleParam.Mode.convert
                    Opacity             |> DynObj.setValueOpt scatter "opacity"
                    Ids                 |> DynObj.setValueOpt scatter "ids"
                    X                   |> DynObj.setValueOpt scatter "x"
                    Y                   |> DynObj.setValueOpt scatter "y"
                    Z                   |> DynObj.setValueOpt scatter "z"
                    SurfaceColor        |> DynObj.setValueOpt scatter "surfacecolor"
                    Text                |> DynObj.setValueOpt scatter "text"
                    TextPosition        |> DynObj.setValueOptBy scatter "textposition" StyleParam.TextPosition.convert
                    TextTemplate        |> DynObj.setValueOpt scatter "texttemplate"
                    HoverText           |> DynObj.setValueOpt scatter "hovertext"
                    HoverInfo           |> DynObj.setValueOpt scatter "hoverinfo"
                    HoverTemplate       |> DynObj.setValueOpt scatter "hovertemplate"
                    XHoverFormat        |> DynObj.setValueOpt scatter "xhoverformat"
                    YHoverFormat        |> DynObj.setValueOpt scatter "yhoverformat"
                    ZHoverFormat        |> DynObj.setValueOpt scatter "zhoverformat"
                    Meta                |> DynObj.setValueOpt scatter "meta"
                    CustomData          |> DynObj.setValueOpt scatter "customdata"
                    Scene               |> DynObj.setValueOptBy scatter "scene" StyleParam.SubPlotId.convert
                    Marker              |> DynObj.setValueOpt scatter "marker"
                    Line                |> DynObj.setValueOpt scatter "line"
                    TextFont            |> DynObj.setValueOpt scatter "textfont"
                    ErrorX              |> DynObj.setValueOpt scatter "errorx"
                    ErrorY              |> DynObj.setValueOpt scatter "errory"
                    ErrorZ              |> DynObj.setValueOpt scatter "errorz"
                    ConnectGaps         |> DynObj.setValueOpt scatter "connectgaps"
                    Hoverlabel          |> DynObj.setValueOpt scatter "hoverlabel"
                    Projection          |> DynObj.setValueOpt scatter "projection"
                    Surfaceaxis         |> DynObj.setValueOptBy scatter "surfaceaxis" StyleParam.SurfaceAxis.convert
                    XCalendar           |> DynObj.setValueOptBy scatter "xcalendar" StyleParam.Calendar.convert
                    YCalendar           |> DynObj.setValueOptBy scatter "ycalendar" StyleParam.Calendar.convert
                    ZCalendar           |> DynObj.setValueOptBy scatter "zcalendar" StyleParam.Calendar.convert
                    UIRevision          |> DynObj.setValueOpt scatter "uirevision"

                    scatter
                )



        /// <summary>
        /// Applies the style parameters of the surface chart to the given trace
        /// </summary>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
        /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
        /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
        /// <param name="Opacity">Sets the opacity of the surface. Please note that in the case of using high `opacity` values for example a value greater than or equal to 0.5 on two surfaces (and 0.25 with four surfaces), an overlay of multiple transparent surfaces may not perfectly be sorted in depth by the webgl API. This behavior may be improved in the near future and is subject to change.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
        /// <param name="X">Sets the x coordinates.</param>
        /// <param name="Y">Sets the y coordinates.</param>
        /// <param name="Z">Sets the z coordinates.</param>
        /// <param name="SurfaceColor">Sets the surface color values, used for setting a color scale independent of `z`.</param>
        /// <param name="Text">Sets the text elements associated with each z value. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="HoverText">Same as `text`.</param>
        /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
        /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
        /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
        /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `yaxis.hoverformat`.</param>
        /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `zaxis.hoverformat`.</param>
        /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
        /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
        /// <param name="Scene">Sets a reference between this trace's 3D coordinate system and a 3D scene. If "scene" (the default value), the (x,y,z) coordinates refer to `layout.scene`. If "scene2", the (x,y,z) coordinates refer to `layout.scene2`, and so on.</param>
        /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
        /// <param name="ColorBar">Sets the colorbar of this trace.</param>
        /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
        /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
        /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
        /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here z or surfacecolor) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
        /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as z or surfacecolor and if set, `cmax` must be set as well.</param>
        /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as z or surfacecolor. Has no effect when `cauto` is `false`.</param>
        /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as z or surfacecolor and if set, `cmin` must be set as well.</param>
        /// <param name="ConnectGaps">Determines whether or not gaps (i.e. {nan} or missing values) in the `z` data are filled in.</param>
        /// <param name="Contours">Sets the contours of this trace.</param>
        /// <param name="HideSurface">Determines whether or not a surface is drawn. For example, set `hidesurface` to "false" `contours.x.show` to "true" and `contours.y.show` to "true" to draw a wire frame plot.</param>
        /// <param name="Hoverlabel">Sets the hoverlabel style of this trace.</param>
        /// <param name="Lighting">Sets the Lighting style of this trace.</param>
        /// <param name="LightPosition">Sets the LightPosition style of this trace.</param>
        /// <param name="OpacityScale">Sets the opacityscale. The opacityscale must be an array containing arrays mapping a normalized value to an opacity value. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 1], [0.5, 0.2], [1, 1]]` means that higher/lower values would have higher opacity values and those in the middle would be more transparent Alternatively, `opacityscale` may be a palette name string of the following list: 'min', 'max', 'extremes' and 'uniform'. The default is 'uniform'.</param>
        /// <param name="XCalendar">Sets the calendar system to use with `x` date data.</param>
        /// <param name="YCalendar">Sets the calendar system to use with `y` date data.</param>
        /// <param name="ZCalendar">Sets the calendar system to use with `z` date data.</param>
        /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
        static member Surface
            (                
                ?Name               : string,
                ?Visible            : StyleParam.Visible,
                ?ShowLegend         : bool,
                ?LegendRank         : int,
                ?LegendGroup        : string,
                ?LegendGroupTitle   : Title,
                ?Opacity            : float,
                ?Ids                : seq<#IConvertible>,
                ?X                  : seq<#IConvertible>,
                ?Y                  : seq<#IConvertible>,
                ?Z                  : seq<#seq<#IConvertible>>,
                ?SurfaceColor       : string,
                ?Text               : seq<#IConvertible>,
                ?HoverText          : seq<#IConvertible>,
                ?HoverInfo          : string,
                ?HoverTemplate      : string,
                ?XHoverFormat       : string,
                ?YHoverFormat       : string,
                ?ZHoverFormat       : string,
                ?Meta               : string,
                ?CustomData         : seq<#IConvertible>,
                ?Scene              : StyleParam.SubPlotId,
                ?ColorAxis          : StyleParam.SubPlotId,
                ?ColorBar           : ColorBar,
                ?AutoColorScale     : bool,
                ?ColorScale         : StyleParam.Colorscale,
                ?ShowScale          : bool,
                ?ReverseScale       : bool,
                ?CAuto              : bool,
                ?CMin               : float,
                ?CMid               : float,
                ?CMax               : float,
                ?ConnectGaps        : bool,
                ?Contours           : Contours,
                ?HideSurface        : bool,
                ?Hoverlabel         : Hoverlabel,
                ?Lighting           : Lighting,
                ?LightPosition      : LightPosition,
                ?OpacityScale       : seq<#seq<#IConvertible>>,
                ?XCalendar          : StyleParam.Calendar,
                ?YCalendar          : StyleParam.Calendar,
                ?ZCalendar          : StyleParam.Calendar,
                ?UIRevision         : string
            ) =
                (fun (surface: #Trace) -> 

                    Name               |> DynObj.setValueOpt surface "name"
                    Visible            |> DynObj.setValueOptBy surface "visible" StyleParam.Visible.convert
                    ShowLegend         |> DynObj.setValueOpt surface "showlegend"
                    LegendRank         |> DynObj.setValueOpt surface "legendrank"
                    LegendGroup        |> DynObj.setValueOpt surface "legendgroup"
                    LegendGroupTitle   |> DynObj.setValueOpt surface "legendgrouptitle"
                    Opacity            |> DynObj.setValueOpt surface "opacity"
                    Ids                |> DynObj.setValueOpt surface "ids"
                    X                  |> DynObj.setValueOpt surface "x"
                    Y                  |> DynObj.setValueOpt surface "y"
                    Z                  |> DynObj.setValueOpt surface "z"
                    SurfaceColor       |> DynObj.setValueOpt surface "surfacecolor"
                    Text               |> DynObj.setValueOpt surface "text"
                    HoverText          |> DynObj.setValueOpt surface "hovertext"
                    HoverInfo          |> DynObj.setValueOpt surface "hoverinfo"
                    HoverTemplate      |> DynObj.setValueOpt surface "hovertemplate"
                    XHoverFormat       |> DynObj.setValueOpt surface "xhoverformat"
                    YHoverFormat       |> DynObj.setValueOpt surface "yhoverformat"
                    ZHoverFormat       |> DynObj.setValueOpt surface "zhoverformat"
                    Meta               |> DynObj.setValueOpt surface "meta"
                    CustomData         |> DynObj.setValueOpt surface "customdata"
                    Scene              |> DynObj.setValueOptBy surface "scene" StyleParam.SubPlotId.convert
                    ColorAxis          |> DynObj.setValueOptBy surface "coloraxis" StyleParam.SubPlotId.convert
                    ColorBar           |> DynObj.setValueOpt surface "colorbar"
                    AutoColorScale     |> DynObj.setValueOpt surface "autocolorscale"
                    ColorScale         |> DynObj.setValueOptBy surface "colorscale" StyleParam.Colorscale.convert
                    ShowScale          |> DynObj.setValueOpt surface "showscale"
                    ReverseScale       |> DynObj.setValueOpt surface "reversescale"
                    CAuto              |> DynObj.setValueOpt surface "cauto"
                    CMin               |> DynObj.setValueOpt surface "cmin"
                    CMid               |> DynObj.setValueOpt surface "cmid"
                    CMax               |> DynObj.setValueOpt surface "cmax"
                    ConnectGaps        |> DynObj.setValueOpt surface "connectgaps"
                    Contours           |> DynObj.setValueOpt surface "contours"
                    HideSurface        |> DynObj.setValueOpt surface "hidesurface"
                    Hoverlabel         |> DynObj.setValueOpt surface "hoverlabel"
                    Lighting           |> DynObj.setValueOpt surface "lighting"
                    LightPosition      |> DynObj.setValueOpt surface "lightposition"
                    OpacityScale       |> DynObj.setValueOpt surface "opacityscale"
                    XCalendar          |> DynObj.setValueOptBy surface "xcalendar" StyleParam.Calendar.convert
                    YCalendar          |> DynObj.setValueOptBy surface "ycalendar" StyleParam.Calendar.convert
                    ZCalendar          |> DynObj.setValueOptBy surface "zcalendar" StyleParam.Calendar.convert
                    UIRevision         |> DynObj.setValueOpt surface "uirevision"
                    
                    surface 
                )


        /// <summary>
        /// Applies the style parameters of the mesh3d chart to the given trace
        /// </summary>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
        /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
        /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
        /// <param name="Opacity">Sets the opacity of the surface. Please note that in the case of using high `opacity` values for example a value greater than or equal to 0.5 on two surfaces (and 0.25 with four surfaces), an overlay of multiple transparent surfaces may not perfectly be sorted in depth by the webgl API. This behavior may be improved in the near future and is subject to change.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
        /// <param name="X">Sets the X coordinates of the vertices. The nth element of vectors `x`, `y` and `z` jointly represent the X, Y and Z coordinates of the nth vertex.</param>
        /// <param name="Y">Sets the Y coordinates of the vertices. The nth element of vectors `x`, `y` and `z` jointly represent the X, Y and Z coordinates of the nth vertex.</param>
        /// <param name="Z">Sets the Z coordinates of the vertices. The nth element of vectors `x`, `y` and `z` jointly represent the X, Y and Z coordinates of the nth vertex.</param>
        /// <param name="I">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "first" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `i[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `i` represents a point in space, which is the first vertex of a triangle.</param>
        /// <param name="J">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "second" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `j[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `j` represents a point in space, which is the second vertex of a triangle.</param>
        /// <param name="K">A vector of vertex indices, i.e. integer values between 0 and the length of the vertex vectors, representing the "third" vertex of a triangle. For example, `{i[m], j[m], k[m]}` together represent face m (triangle m) in the mesh, where `k[m] = n` points to the triplet `{x[n], y[n], z[n]}` in the vertex arrays. Therefore, each element in `k` represents a point in space, which is the third vertex of a triangle.</param>
        /// <param name="FaceColor">Sets the color of each face Overrides "color" and "vertexcolor".</param>
        /// <param name="Intensity">Sets the intensity values for vertices or cells as defined by `intensitymode`. It can be used for plotting fields on meshes.</param>
        /// <param name="IntensityMode">Determines the source of `intensity` values.</param>
        /// <param name="VertexColor">Sets the color of each vertex Overrides "color". While Red, green and blue colors are in the range of 0 and 255; in the case of having vertex color data in RGBA format, the alpha color should be normalized to be between 0 and 1.</param>
        /// <param name="Text">Sets the text elements associated with the vertices. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="HoverText">Same as `text`.</param>
        /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
        /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
        /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
        /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `yaxis.hoverformat`.</param>
        /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `zaxis.hoverformat`.</param>
        /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
        /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
        /// <param name="Scene">Sets a reference between this trace's 3D coordinate system and a 3D scene. If "scene" (the default value), the (x,y,z) coordinates refer to `layout.scene`. If "scene2", the (x,y,z) coordinates refer to `layout.scene2`, and so on.</param>
        /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
        /// <param name="ColorBar">Sets the colorbar of this trace.</param>
        /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
        /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
        /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
        /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here z or surfacecolor) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
        /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as z or surfacecolor and if set, `cmax` must be set as well.</param>
        /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as z or surfacecolor. Has no effect when `cauto` is `false`.</param>
        /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as z or surfacecolor and if set, `cmin` must be set as well.</param>
        /// <param name="AlphaHull">Determines how the mesh surface triangles are derived from the set of vertices (points) represented by the `x`, `y` and `z` arrays, if the `i`, `j`, `k` arrays are not supplied. For general use of `mesh3d` it is preferred that `i`, `j`, `k` are supplied. If "-1", Delaunay triangulation is used, which is mainly suitable if the mesh is a single, more or less layer surface that is perpendicular to `delaunayaxis`. In case the `delaunayaxis` intersects the mesh surface at more than one point it will result triangles that are very long in the dimension of `delaunayaxis`. If ">0", the alpha-shape algorithm is used. In this case, the positive `alphahull` value signals the use of the alpha-shape algorithm, _and_ its value acts as the parameter for the mesh fitting. If "0", the convex-hull algorithm is used. It is suitable for convex bodies or if the intention is to enclose the `x`, `y` and `z` point set into a convex hull.</param>
        /// <param name="Delaunayaxis">Sets the Delaunay axis, which is the axis that is perpendicular to the surface of the Delaunay triangulation. It has an effect if `i`, `j`, `k` are not provided and `alphahull` is set to indicate Delaunay triangulation.</param>
        /// <param name="Contour">Sets the contour of this trace</param>
        /// <param name="FlatShading">Determines whether or not normal smoothing is applied to the meshes, creating meshes with an angular, low-poly look via flat reflections.</param>
        /// <param name="Hoverlabel">Sets the hoverlabel style of this trace.</param>
        /// <param name="Lighting">Sets the Lighting style of this trace.</param>
        /// <param name="LightPosition">Sets the LightPosition style of this trace.</param>
        /// <param name="XCalendar">Sets the calendar system to use with `x` date data.</param>
        /// <param name="YCalendar">Sets the calendar system to use with `y` date data.</param>
        /// <param name="ZCalendar">Sets the calendar system to use with `z` date data.</param>
        /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
        static member Mesh3d
            (   
                ?Name               : string,
                ?Visible            : StyleParam.Visible,
                ?ShowLegend         : bool,
                ?LegendRank         : int,
                ?LegendGroup        : string,
                ?LegendGroupTitle   : Title,
                ?Opacity            : float,
                ?Ids                : seq<#IConvertible>,
                ?X                  : seq<#IConvertible>,
                ?Y                  : seq<#IConvertible>,
                ?Z                  : seq<#IConvertible>,
                ?I                  : seq<#IConvertible>,
                ?J                  : seq<#IConvertible>,
                ?K                  : seq<#IConvertible>,
                ?FaceColor          : seq<#IConvertible>,
                ?Intensity          : seq<#IConvertible>,
                ?IntensityMode      : StyleParam.IntensityMode,
                ?VertexColor        : seq<#IConvertible>,
                ?Text               : seq<#IConvertible>,
                ?HoverText          : seq<#IConvertible>,
                ?HoverInfo          : string,
                ?HoverTemplate      : string,
                ?XHoverFormat       : string,
                ?YHoverFormat       : string,
                ?ZHoverFormat       : string,
                ?Meta               : string,
                ?CustomData         : seq<#IConvertible>,
                ?Scene              : StyleParam.SubPlotId,
                ?ColorAxis          : StyleParam.SubPlotId,
                ?ColorBar           : ColorBar,
                ?AutoColorScale     : bool,
                ?ColorScale         : StyleParam.Colorscale,
                ?ShowScale          : bool,
                ?ReverseScale       : bool,
                ?CAuto              : bool,
                ?CMin               : float,
                ?CMid               : float,
                ?CMax               : float,
                ?AlphaHull          : float,
                ?Delaunayaxis       : StyleParam.Delaunayaxis, 
                ?Contour            : Contour,
                ?FlatShading        : bool,
                ?Hoverlabel         : Hoverlabel,
                ?Lighting           : Lighting,
                ?LightPosition      : LightPosition,
                ?XCalendar          : StyleParam.Calendar,
                ?YCalendar          : StyleParam.Calendar,
                ?ZCalendar          : StyleParam.Calendar,
                ?UIRevision         : string
            ) =

                fun (mesh3d: #Trace) ->

                     Name               |> DynObj.setValueOpt mesh3d "name"
                     Visible            |> DynObj.setValueOptBy mesh3d "visible" StyleParam.Visible.convert
                     ShowLegend         |> DynObj.setValueOpt mesh3d "showlegend"
                     LegendRank         |> DynObj.setValueOpt mesh3d "legendrank"
                     LegendGroup        |> DynObj.setValueOpt mesh3d "legendgroup"
                     LegendGroupTitle   |> DynObj.setValueOpt mesh3d "legendgrouptitle"
                     Opacity            |> DynObj.setValueOpt mesh3d "opacity"
                     Ids                |> DynObj.setValueOpt mesh3d "ids"
                     X                  |> DynObj.setValueOpt mesh3d "x"
                     Y                  |> DynObj.setValueOpt mesh3d "y"
                     Z                  |> DynObj.setValueOpt mesh3d "z"
                     I                  |> DynObj.setValueOpt mesh3d "i"
                     J                  |> DynObj.setValueOpt mesh3d "j"
                     K                  |> DynObj.setValueOpt mesh3d "k"
                     FaceColor          |> DynObj.setValueOpt mesh3d "facecolor"
                     Intensity          |> DynObj.setValueOpt mesh3d "intensity"
                     IntensityMode      |> DynObj.setValueOptBy mesh3d "intensitymode" StyleParam.IntensityMode.convert
                     VertexColor        |> DynObj.setValueOpt mesh3d "vertexcolor"
                     Text               |> DynObj.setValueOpt mesh3d "text"
                     HoverText          |> DynObj.setValueOpt mesh3d "hovertext"
                     HoverInfo          |> DynObj.setValueOpt mesh3d "hoverinfo"
                     HoverTemplate      |> DynObj.setValueOpt mesh3d "hovertemplate"
                     XHoverFormat       |> DynObj.setValueOpt mesh3d "xhoverformat"
                     YHoverFormat       |> DynObj.setValueOpt mesh3d "yhoverformat"
                     ZHoverFormat       |> DynObj.setValueOpt mesh3d "zhoverformat"
                     Meta               |> DynObj.setValueOpt mesh3d "meta"
                     CustomData         |> DynObj.setValueOpt mesh3d "customdata"
                     Scene              |> DynObj.setValueOptBy mesh3d "scene" StyleParam.SubPlotId.convert
                     ColorAxis          |> DynObj.setValueOptBy mesh3d "coloraxis" StyleParam.SubPlotId.convert
                     ColorBar           |> DynObj.setValueOpt mesh3d "colorbar"
                     AutoColorScale     |> DynObj.setValueOpt mesh3d "autocolorscale"
                     ColorScale         |> DynObj.setValueOptBy mesh3d "colorscale" StyleParam.Colorscale.convert
                     ShowScale          |> DynObj.setValueOpt mesh3d "showscale"
                     ReverseScale       |> DynObj.setValueOpt mesh3d "reversescale"
                     CAuto              |> DynObj.setValueOpt mesh3d "cauto"
                     CMin               |> DynObj.setValueOpt mesh3d "cmin"
                     CMid               |> DynObj.setValueOpt mesh3d "cmid"
                     CMax               |> DynObj.setValueOpt mesh3d "cmax"
                     AlphaHull          |> DynObj.setValueOpt mesh3d "alphahull"
                     Delaunayaxis       |> DynObj.setValueOptBy mesh3d "delaunayaxis" StyleParam.Delaunayaxis.convert
                     Contour            |> DynObj.setValueOpt mesh3d "contour"
                     FlatShading        |> DynObj.setValueOpt mesh3d "flatshading"
                     Hoverlabel         |> DynObj.setValueOpt mesh3d "hoverlabel"
                     Lighting           |> DynObj.setValueOpt mesh3d "lighting"
                     LightPosition      |> DynObj.setValueOpt mesh3d "lightposition"
                     XCalendar          |> DynObj.setValueOptBy mesh3d "xcalendar" StyleParam.Calendar.convert
                     YCalendar          |> DynObj.setValueOptBy mesh3d "ycalendar" StyleParam.Calendar.convert
                     ZCalendar          |> DynObj.setValueOptBy mesh3d "zcalendar" StyleParam.Calendar.convert
                     UIRevision         |> DynObj.setValueOpt mesh3d "uirevision"

                     mesh3d
                

        /// <summary>
        /// Applies the style parameters of the cone chart to the given trace
        /// </summary>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
        /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
        /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
        /// <param name="Opacity">Sets the opacity of the surface. Please note that in the case of using high `opacity` values for example a value greater than or equal to 0.5 on two surfaces (and 0.25 with four surfaces), an overlay of multiple transparent surfaces may not perfectly be sorted in depth by the webgl API. This behavior may be improved in the near future and is subject to change.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
        /// <param name="X">Sets the x coordinates of the vector field and of the displayed cones.</param>
        /// <param name="Y">Sets the y coordinates of the vector field and of the displayed cones.</param>
        /// <param name="Z">Sets the z coordinates of the vector field and of the displayed cones.</param>
        /// <param name="U">Sets the x components of the vector field.</param>
        /// <param name="V">Sets the y components of the vector field.</param>
        /// <param name="W">Sets the z components of the vector field.</param>
        /// <param name="Text">Sets the text elements associated with the cones. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="HoverText">Same as `text`.</param>
        /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
        /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
        /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
        /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `yaxis.hoverformat`.</param>
        /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `zaxis.hoverformat`</param>
        /// <param name="UHoverFormat">Sets the hover text formatting rulefor `u` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
        /// <param name="VHoverFormat">Sets the hover text formatting rulefor `v` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
        /// <param name="WHoverFormat">Sets the hover text formatting rulefor `w` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
        /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
        /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
        /// <param name="Scene">Sets a reference between this trace's 3D coordinate system and a 3D scene. If "scene" (the default value), the (x,y,z) coordinates refer to `layout.scene`. If "scene2", the (x,y,z) coordinates refer to `layout.scene2`, and so on.</param>
        /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
        /// <param name="ColorBar">Sets the ColorBar object associated with the color scale of the cones</param>
        /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
        /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
        /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
        /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here u/v/w norm) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
        /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as u/v/w norm and if set, `cmin` must be set as well.</param>
        /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as u/v/w norm. Has no effect when `cauto` is `false`.</param>
        /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as u/v/w norm and if set, `cmax` must be set as well.</param>
        /// <param name="Anchor">Sets the cones' anchor with respect to their x/y/z positions. Note that "cm" denote the cone's center of mass which corresponds to 1/4 from the tail to tip.</param>
        /// <param name="HoverLabel">Sets the hover labels of this cone trace.</param>
        /// <param name="Lighting">Sets the Lighting of this cone trace.</param>
        /// <param name="LightPosition">Sets the LightPosition of this cone trace.</param>
        /// <param name="SizeMode">Determines whether `sizeref` is set as a "scaled" (i.e unitless) scalar (normalized by the max u/v/w norm in the vector field) or as "absolute" value (in the same units as the vector field).</param>
        /// <param name="SizeRef">Adjusts the cone size scaling. The size of the cones is determined by their u/v/w norm multiplied a factor and `sizeref`. This factor (computed internally) corresponds to the minimum "time" to travel across two successive x/y/z positions at the average velocity of those two successive positions. All cones in a given trace use the same factor. With `sizemode` set to "scaled", `sizeref` is unitless, its default value is "0.5" With `sizemode` set to "absolute", `sizeref` has the same units as the u/v/w vector field, its the default value is half the sample's maximum vector norm.</param>
        /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
        static member Cone 
            (
                ?Name               : string,
                ?Visible            : StyleParam.Visible,
                ?ShowLegend         : bool,
                ?LegendRank         : int,
                ?LegendGroup        : string,
                ?LegendGroupTitle   : Title,
                ?Opacity            : float,
                ?Ids                : seq<#IConvertible>,
                ?X                  : seq<#IConvertible>,
                ?Y                  : seq<#IConvertible>,
                ?Z                  : seq<#IConvertible>,
                ?U                  : seq<#IConvertible>,
                ?V                  : seq<#IConvertible>,
                ?W                  : seq<#IConvertible>,
                ?Text               : seq<#IConvertible>,
                ?HoverText          : seq<#IConvertible>,
                ?HoverInfo          : string,
                ?HoverTemplate      : string,
                ?XHoverFormat       : string,
                ?YHoverFormat       : string,
                ?ZHoverFormat       : string,
                ?UHoverFormat       : string,
                ?VHoverFormat       : string,
                ?WHoverFormat       : string,
                ?Meta               : seq<#IConvertible>,
                ?CustomData         : seq<#IConvertible>,
                ?Scene              : StyleParam.SubPlotId,
                ?ColorAxis          : StyleParam.SubPlotId,
                ?ColorBar           : ColorBar,
                ?AutoColorScale     : bool,
                ?ColorScale         : StyleParam.Colorscale,
                ?ShowScale          : bool,
                ?ReverseScale       : bool,
                ?CAuto              : bool,
                ?CMin               : float,
                ?CMid               : float,
                ?CMax               : float,
                ?Anchor             : StyleParam.ConeAnchor,
                ?HoverLabel         : Hoverlabel,
                ?Lighting           : Lighting,
                ?LightPosition      : LightPosition,
                ?SizeMode           : StyleParam.ConeSizeMode,
                ?SizeRef            : float,
                ?UIRevision         : seq<#IConvertible>

            ) =
                (fun (cone: #Trace) -> 
                    Name                |> DynObj.setValueOpt cone "name"
                    Visible             |> DynObj.setValueOptBy cone "visible" StyleParam.Visible.convert
                    ShowLegend          |> DynObj.setValueOpt cone "showlegend"
                    LegendRank          |> DynObj.setValueOpt cone "legendrank"
                    LegendGroup         |> DynObj.setValueOpt cone "legendgroup"
                    LegendGroupTitle    |> DynObj.setValueOpt cone "legendgrouptitle"
                    Opacity             |> DynObj.setValueOpt cone "opacity"
                    Ids                 |> DynObj.setValueOpt cone "ids"
                    X                   |> DynObj.setValueOpt cone "x"
                    Y                   |> DynObj.setValueOpt cone "y"
                    Z                   |> DynObj.setValueOpt cone "z"
                    U                   |> DynObj.setValueOpt cone "u"
                    V                   |> DynObj.setValueOpt cone "v"
                    W                   |> DynObj.setValueOpt cone "w"
                    Text                |> DynObj.setValueOpt cone "text"
                    HoverText           |> DynObj.setValueOpt cone "hovertext"
                    HoverInfo           |> DynObj.setValueOpt cone "hoverinfo"
                    HoverTemplate       |> DynObj.setValueOpt cone "hovertemplate"
                    XHoverFormat        |> DynObj.setValueOpt cone "xhoverformat"
                    YHoverFormat        |> DynObj.setValueOpt cone "yhoverformat"
                    ZHoverFormat        |> DynObj.setValueOpt cone "zhoverformat"
                    UHoverFormat        |> DynObj.setValueOpt cone "uhoverformat"
                    VHoverFormat        |> DynObj.setValueOpt cone "vhoverformat"
                    WHoverFormat        |> DynObj.setValueOpt cone "whoverformat"
                    Meta                |> DynObj.setValueOpt cone "meta"
                    CustomData          |> DynObj.setValueOpt cone "customdata"
                    Scene               |> DynObj.setValueOptBy cone "scene" StyleParam.SubPlotId.convert
                    ColorAxis           |> DynObj.setValueOptBy cone "scene" StyleParam.SubPlotId.convert
                    ColorBar            |> DynObj.setValueOpt cone "colorbar"
                    AutoColorScale      |> DynObj.setValueOpt cone "autocolorscale"
                    ColorScale          |> DynObj.setValueOptBy cone "colorscale" StyleParam.Colorscale.convert
                    ShowScale           |> DynObj.setValueOpt cone "showscale"
                    ReverseScale        |> DynObj.setValueOpt cone "reversescale"
                    CAuto               |> DynObj.setValueOpt cone "cauto"
                    CMin                |> DynObj.setValueOpt cone "cmin"
                    CMid                |> DynObj.setValueOpt cone "cmid"
                    CMax                |> DynObj.setValueOpt cone "cmax"
                    Anchor              |> DynObj.setValueOptBy cone "anchor" StyleParam.ConeAnchor.convert
                    HoverLabel          |> DynObj.setValueOpt cone "hoverlabel"
                    Lighting            |> DynObj.setValueOpt cone "lighting"
                    LightPosition       |> DynObj.setValueOpt cone "lightposition"
                    SizeMode            |> DynObj.setValueOptBy cone "sizemode" StyleParam.ConeSizeMode.convert
                    SizeRef             |> DynObj.setValueOpt cone "sizeref"
                    UIRevision          |> DynObj.setValueOpt cone "uirevision"

                    cone
                )

        /// <summary>
        /// Applies the style parameters of the streamtube chart to the given trace
        /// </summary>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
        /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
        /// <param name="LegendGroupTitle">Sets the legend group title for this trace.</param>
        /// <param name="Opacity">Sets the opacity of the surface. Please note that in the case of using high `opacity` values for example a value greater than or equal to 0.5 on two surfaces (and 0.25 with four surfaces), an overlay of multiple transparent surfaces may not perfectly be sorted in depth by the webgl API. This behavior may be improved in the near future and is subject to change.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
        /// <param name="X">Sets the x coordinates of the vector field.</param>
        /// <param name="Y">Sets the y coordinates of the vector field.</param>
        /// <param name="Z">Sets the z coordinates of the vector field.</param>
        /// <param name="U">Sets the x components of the vector field.</param>
        /// <param name="V">Sets the y components of the vector field.</param>
        /// <param name="W">Sets the z components of the vector field.</param>
        /// <param name="Text">Sets a text element associated with this trace. If trace `hoverinfo` contains a "text" flag, this text element will be seen in all hover labels. Note that streamtube traces do not support array `text` values.</param>
        /// <param name="HoverText">Same as `text`.</param>
        /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
        /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
        /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
        /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `yaxis.hoverformat`.</param>
        /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `zaxis.hoverformat`</param>
        /// <param name="UHoverFormat">Sets the hover text formatting rulefor `u` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
        /// <param name="VHoverFormat">Sets the hover text formatting rulefor `v` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
        /// <param name="WHoverFormat">Sets the hover text formatting rulefor `w` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
        /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
        /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
        /// <param name="Scene">Sets a reference between this trace's 3D coordinate system and a 3D scene. If "scene" (the default value), the (x,y,z) coordinates refer to `layout.scene`. If "scene2", the (x,y,z) coordinates refer to `layout.scene2`, and so on.</param>
        /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
        /// <param name="ColorBar">Sets the ColorBar object associated with the color scale of the streamtubes</param>
        /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
        /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
        /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
        /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here u/v/w norm) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
        /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as u/v/w norm and if set, `cmin` must be set as well.</param>
        /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as u/v/w norm. Has no effect when `cauto` is `false`.</param>
        /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as u/v/w norm and if set, `cmax` must be set as well.</param>
        /// <param name="HoverLabel">Sets the hover labels of this trace.</param>
        /// <param name="Lighting">Sets the Lighting of this trace.</param>
        /// <param name="LightPosition">Sets the LightPosition of this trace.</param>
        /// <param name="MaxDisplayed">The maximum number of displayed segments in a streamtube.</param>
        /// <param name="SizeRef">The scaling factor for the streamtubes. The default is 1, which avoids two max divergence tubes from touching at adjacent starting positions.</param>
        /// <param name="Starts">Sets the streamtube starting positions</param>
        /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
        static member StreamTube 
            (
                ?Name               : string,
                ?Visible            : StyleParam.Visible,
                ?ShowLegend         : bool,
                ?LegendRank         : int,
                ?LegendGroup        : string,
                ?LegendGroupTitle   : Title,
                ?Opacity            : float,
                ?Ids                : seq<#IConvertible>,
                ?X                  : seq<#IConvertible>,
                ?Y                  : seq<#IConvertible>,
                ?Z                  : seq<#IConvertible>,
                ?U                  : seq<#IConvertible>,
                ?V                  : seq<#IConvertible>,
                ?W                  : seq<#IConvertible>,
                ?Text               : seq<#IConvertible>,
                ?HoverText          : seq<#IConvertible>,
                ?HoverInfo          : string,
                ?HoverTemplate      : string,
                ?XHoverFormat       : string,
                ?YHoverFormat       : string,
                ?ZHoverFormat       : string,
                ?UHoverFormat       : string,
                ?VHoverFormat       : string,
                ?WHoverFormat       : string,
                ?Meta               : seq<#IConvertible>,
                ?CustomData         : seq<#IConvertible>,
                ?Scene              : StyleParam.SubPlotId,
                ?ColorAxis          : StyleParam.SubPlotId,
                ?ColorBar           : ColorBar,
                ?AutoColorScale     : bool,
                ?ColorScale         : StyleParam.Colorscale,
                ?ShowScale          : bool,
                ?ReverseScale       : bool,
                ?CAuto              : bool,
                ?CMin               : float,
                ?CMid               : float,
                ?CMax               : float,
                ?HoverLabel         : Hoverlabel,
                ?Lighting           : Lighting,
                ?LightPosition      : LightPosition,
                ?MaxDisplayed       : int,
                ?SizeRef            : float,
                ?Starts             : StreamTubeStarts,
                ?UIRevision         : seq<#IConvertible>

            ) =
                (fun (streamTube: #Trace) -> 
                    Name                |> DynObj.setValueOpt streamTube "name"
                    Visible             |> DynObj.setValueOptBy streamTube "visible" StyleParam.Visible.convert
                    ShowLegend          |> DynObj.setValueOpt streamTube "showlegend"
                    LegendRank          |> DynObj.setValueOpt streamTube "legendrank"
                    LegendGroup         |> DynObj.setValueOpt streamTube "legendgroup"
                    LegendGroupTitle    |> DynObj.setValueOpt streamTube "legendgrouptitle"
                    Opacity             |> DynObj.setValueOpt streamTube "opacity"
                    Ids                 |> DynObj.setValueOpt streamTube "ids"
                    X                   |> DynObj.setValueOpt streamTube "x"
                    Y                   |> DynObj.setValueOpt streamTube "y"
                    Z                   |> DynObj.setValueOpt streamTube "z"
                    U                   |> DynObj.setValueOpt streamTube "u"
                    V                   |> DynObj.setValueOpt streamTube "v"
                    W                   |> DynObj.setValueOpt streamTube "w"
                    Text                |> DynObj.setValueOpt streamTube "text"
                    HoverText           |> DynObj.setValueOpt streamTube "hovertext"
                    HoverInfo           |> DynObj.setValueOpt streamTube "hoverinfo"
                    HoverTemplate       |> DynObj.setValueOpt streamTube "hovertemplate"
                    XHoverFormat        |> DynObj.setValueOpt streamTube "xhoverformat"
                    YHoverFormat        |> DynObj.setValueOpt streamTube "yhoverformat"
                    ZHoverFormat        |> DynObj.setValueOpt streamTube "zhoverformat"
                    UHoverFormat        |> DynObj.setValueOpt streamTube "uhoverformat"
                    VHoverFormat        |> DynObj.setValueOpt streamTube "vhoverformat"
                    WHoverFormat        |> DynObj.setValueOpt streamTube "whoverformat"
                    Meta                |> DynObj.setValueOpt streamTube "meta"
                    CustomData          |> DynObj.setValueOpt streamTube "customdata"
                    Scene               |> DynObj.setValueOptBy streamTube "scene" StyleParam.SubPlotId.convert
                    ColorAxis           |> DynObj.setValueOptBy streamTube "scene" StyleParam.SubPlotId.convert
                    ColorBar            |> DynObj.setValueOpt streamTube "colorbar"
                    AutoColorScale      |> DynObj.setValueOpt streamTube "autocolorscale"
                    ColorScale          |> DynObj.setValueOptBy streamTube "colorscale" StyleParam.Colorscale.convert
                    ShowScale           |> DynObj.setValueOpt streamTube "showscale"
                    ReverseScale        |> DynObj.setValueOpt streamTube "reversescale"
                    CAuto               |> DynObj.setValueOpt streamTube "cauto"
                    CMin                |> DynObj.setValueOpt streamTube "cmin"
                    CMid                |> DynObj.setValueOpt streamTube "cmid"
                    CMax                |> DynObj.setValueOpt streamTube "cmax"
                    HoverLabel          |> DynObj.setValueOpt streamTube "hoverlabel"
                    Lighting            |> DynObj.setValueOpt streamTube "lighting"
                    LightPosition       |> DynObj.setValueOpt streamTube "lightposition"
                    MaxDisplayed        |> DynObj.setValueOpt streamTube "maxdisplayed"
                    SizeRef             |> DynObj.setValueOpt streamTube "sizeref"
                    Starts              |> DynObj.setValueOpt streamTube "starts"
                    UIRevision          |> DynObj.setValueOpt streamTube "uirevision"

                    streamTube
                )

        /// <summary>
        /// Applies the style parameters of the volume chart to the given trace
        /// </summary>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
        /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
        /// <param name="LegendGroupTitle">Sets the title of the legendgroup</param>
        /// <param name="Opacity">Sets the opacity of the surface. Please note that in the case of using high `opacity` values for example a value greater than or equal to 0.5 on two surfaces (and 0.25 with four surfaces), an overlay of multiple transparent surfaces may not perfectly be sorted in depth by the webgl API. This behavior may be improved in the near future and is subject to change.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
        /// <param name="X">Sets the X coordinates of the vertices on X axis.</param>
        /// <param name="Y">Sets the Y coordinates of the vertices on Y axis.</param>
        /// <param name="Z">Sets the Z coordinates of the vertices on Z axis.</param>
        /// <param name="Value">Sets the 4th dimension (value) of the vertices.</param>
        /// <param name="Text">Sets the text elements associated with the vertices. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="HoverText">Same as `text`.</param>
        /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
        /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
        /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
        /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `yaxis.hoverformat`.</param>
        /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `zaxis.hoverformat`</param>
        /// <param name="ValueHoverFormat">Sets the hover text formatting rulefor `value` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
        /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
        /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
        /// <param name="Scene">Sets a reference between this trace's 3D coordinate system and a 3D scene. If "scene" (the default value), the (x,y,z) coordinates refer to `layout.scene`. If "scene2", the (x,y,z) coordinates refer to `layout.scene2`, and so on.</param>
        /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
        /// <param name="ColorBar">Sets the colorbar of this trace</param>
        /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
        /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
        /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
        /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here `value`) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
        /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as `value` and if set, `cmax` must be set as well.</param>
        /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as `value`. Has no effect when `cauto` is `false`.</param>
        /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as `value` and if set, `cmin` must be set as well.</param>
        /// <param name="Caps">Sets the caps of this trace caps (color-coded surfaces on the sides of the visualization domain)</param>
        /// <param name="Contour">Sets the contour of this trace.</param>
        /// <param name="FlatShading">Determines whether or not normal smoothing is applied to the meshes, creating meshes with an angular, low-poly look via flat reflections.</param>
        /// <param name="HoverLabel">Sets the hover labels of this trace.</param>
        /// <param name="IsoMax">Sets the maximum boundary for iso-surface plot.</param>
        /// <param name="IsoMin">Sets the minimum boundary for iso-surface plot.</param>
        /// <param name="Lighting">Sets the Lighting of this trace.</param>
        /// <param name="LightPosition">Sets the LightPosition of this trace.</param>
        /// <param name="OpacityScale">Sets the opacityscale. The opacityscale must be an array containing arrays mapping a normalized value to an opacity value. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 1], [0.5, 0.2], [1, 1]]` means that higher/lower values would have higher opacity values and those in the middle would be more transparent Alternatively, `opacityscale` may be a palette name string of the following list: 'min', 'max', 'extremes' and 'uniform'. The default is 'uniform'.</param>
        /// <param name="Slices">Sets slices through the volume</param>
        /// <param name="SpaceFrame">Sets the SpaceFrame of this trace.</param>
        /// <param name="Surface">Sets the Surface of this trace.</param>
        /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
        static member Volume 
            (
                ?Name               : string,
                ?Visible            : StyleParam.Visible,
                ?ShowLegend         : bool,
                ?LegendRank         : int,
                ?LegendGroup        : string,
                ?LegendGroupTitle   : Title,
                ?Opacity            : float,
                ?Ids                : seq<#IConvertible>,
                ?X                  : seq<#IConvertible>,
                ?Y                  : seq<#IConvertible>,
                ?Z                  : seq<#IConvertible>,
                ?Value              : seq<#IConvertible>,
                ?Text               : seq<#IConvertible>,
                ?HoverText          : seq<#IConvertible>,
                ?HoverInfo          : string,
                ?HoverTemplate      : string,
                ?XHoverFormat       : string,
                ?YHoverFormat       : string,
                ?ZHoverFormat       : string,
                ?ValueHoverFormat   : string,
                ?Meta               : seq<#IConvertible>,
                ?CustomData         : seq<#IConvertible>,
                ?Scene              : StyleParam.SubPlotId,
                ?ColorAxis          : StyleParam.SubPlotId,
                ?ColorBar           : ColorBar,
                ?AutoColorScale     : bool,
                ?ColorScale         : StyleParam.Colorscale,
                ?ShowScale          : bool,
                ?ReverseScale       : bool,
                ?CAuto              : bool,
                ?CMin               : float,
                ?CMid               : float,
                ?CMax               : float,
                ?Caps               : Caps,
                ?Contour            : Contour,
                ?FlatShading        : bool,
                ?HoverLabel         : Hoverlabel,
                ?IsoMax             : float,
                ?IsoMin             : float,
                ?Lighting           : Lighting,
                ?LightPosition      : LightPosition,
                ?OpacityScale       : seq<#seq<#IConvertible>>,
                ?Slices             : Slices,
                ?SpaceFrame         : Spaceframe,
                ?Surface            : Surface,
                ?UIRevision         : seq<#IConvertible>
            ) =
                fun (volume: #Trace) -> 

                    Name                |> DynObj.setValueOpt volume "name"
                    Visible             |> DynObj.setValueOptBy volume "visible" StyleParam.Visible.convert
                    ShowLegend          |> DynObj.setValueOpt volume "showlegend"
                    LegendRank          |> DynObj.setValueOpt volume "legendrank"
                    LegendGroup         |> DynObj.setValueOpt volume "legendgroup"
                    LegendGroupTitle    |> DynObj.setValueOpt volume "legendgrouptitle"
                    Opacity             |> DynObj.setValueOpt volume "opacity"
                    Ids                 |> DynObj.setValueOpt volume "ids"
                    X                   |> DynObj.setValueOpt volume "x"
                    Y                   |> DynObj.setValueOpt volume "y"
                    Z                   |> DynObj.setValueOpt volume "z"
                    Value               |> DynObj.setValueOpt volume "value"
                    Text                |> DynObj.setValueOpt volume "text"
                    HoverText           |> DynObj.setValueOpt volume "hovertext"
                    HoverInfo           |> DynObj.setValueOpt volume "hoverinfo"
                    HoverTemplate       |> DynObj.setValueOpt volume "hovertemplate"
                    XHoverFormat        |> DynObj.setValueOpt volume "xhoverformat"
                    YHoverFormat        |> DynObj.setValueOpt volume "yhoverformat"
                    ZHoverFormat        |> DynObj.setValueOpt volume "zhoverformat"
                    ValueHoverFormat    |> DynObj.setValueOpt volume "valuehoverformat"
                    Meta                |> DynObj.setValueOpt volume "meta"
                    CustomData          |> DynObj.setValueOpt volume "customdata"
                    Scene               |> DynObj.setValueOptBy volume "scene" StyleParam.SubPlotId.convert
                    ColorAxis           |> DynObj.setValueOptBy volume "scene" StyleParam.SubPlotId.convert
                    ColorBar            |> DynObj.setValueOpt volume "colorbar"
                    AutoColorScale      |> DynObj.setValueOpt volume "autocolorscale"
                    ColorScale          |> DynObj.setValueOptBy volume "colorscale" StyleParam.Colorscale.convert
                    ShowScale           |> DynObj.setValueOpt volume "showscale"
                    ReverseScale        |> DynObj.setValueOpt volume "reversescale"
                    CAuto               |> DynObj.setValueOpt volume "cauto"
                    CMin                |> DynObj.setValueOpt volume "cmin"
                    CMid                |> DynObj.setValueOpt volume "cmid"
                    CMax                |> DynObj.setValueOpt volume "cmax"
                    Caps                |> DynObj.setValueOpt volume "caps"
                    Contour             |> DynObj.setValueOpt volume "contour"
                    FlatShading         |> DynObj.setValueOpt volume "flatshading"
                    HoverLabel          |> DynObj.setValueOpt volume "hoverlabel"
                    IsoMax              |> DynObj.setValueOpt volume "isomax"
                    IsoMin              |> DynObj.setValueOpt volume "isomin"
                    Lighting            |> DynObj.setValueOpt volume "lighting"
                    LightPosition       |> DynObj.setValueOpt volume "lightposition"
                    OpacityScale        |> DynObj.setValueOpt volume "opacityscale"
                    Slices              |> DynObj.setValueOpt volume "slices"
                    SpaceFrame          |> DynObj.setValueOpt volume "spaceframe"
                    Surface             |> DynObj.setValueOpt volume "surface"
                    UIRevision          |> DynObj.setValueOpt volume "uirevision"
                
                    volume
                    
        /// <summary>
        /// Applies the style parameters of the isosurface chart to the given trace
        /// </summary>
        /// <param name="Name">Sets the trace name. The trace name appear as the legend item and on hover.</param>
        /// <param name="Visible">Determines whether or not this trace is visible. If "legendonly", the trace is not drawn, but can appear as a legend item (provided that the legend itself is visible).</param>
        /// <param name="ShowLegend">Determines whether or not an item corresponding to this trace is shown in the legend.</param>
        /// <param name="LegendRank">Sets the legend rank for this trace. Items and groups with smaller ranks are presented on top/left side while with `"reversed" `legend.traceorder` they are on bottom/right side. The default legendrank is 1000, so that you can use ranks less than 1000 to place certain items before all unranked items, and ranks greater than 1000 to go after all unranked items.</param>
        /// <param name="LegendGroup">Sets the legend group for this trace. Traces part of the same legend group hide/show at the same time when toggling legend items.</param>
        /// <param name="LegendGroupTitle">Sets the title of the legendgroup</param>
        /// <param name="Opacity">Sets the opacity of the surface. Please note that in the case of using high `opacity` values for example a value greater than or equal to 0.5 on two surfaces (and 0.25 with four surfaces), an overlay of multiple transparent surfaces may not perfectly be sorted in depth by the webgl API. This behavior may be improved in the near future and is subject to change.</param>
        /// <param name="Ids">Assigns id labels to each datum. These ids for object constancy of data points during animation. Should be an array of strings, not numbers or any other type.</param>
        /// <param name="X">Sets the X coordinates of the vertices on X axis.</param>
        /// <param name="Y">Sets the Y coordinates of the vertices on Y axis.</param>
        /// <param name="Z">Sets the Z coordinates of the vertices on Z axis.</param>
        /// <param name="Value">Sets the 4th dimension (value) of the vertices.</param>
        /// <param name="Text">Sets the text elements associated with the vertices. If trace `hoverinfo` contains a "text" flag and "hovertext" is not set, these elements will be seen in the hover labels.</param>
        /// <param name="HoverText">Same as `text`.</param>
        /// <param name="HoverInfo">Determines which trace information appear on hover. If `none` or `skip` are set, no information is displayed upon hovering. But, if `none` is set, click and hover events are still fired.</param>
        /// <param name="HoverTemplate">Template string used for rendering the information that appear on hover box. Note that this will override `hoverinfo`. Variables are inserted using %{variable}, for example "y: %{y}" as well as %{xother}, {%_xother}, {%_xother_}, {%xother_}. When showing info for several points, "xother" will be added to those with different x positions from the first point. An underscore before or after "(x|y)other" will add a space on that side, only when this field is shown. Numbers are formatted using d3-format's syntax %{variable:d3-format}, for example "Price: %{y:$.2f}". https://github.com/d3/d3-format/tree/v1.4.5#d3-format for details on the formatting syntax. Dates are formatted using d3-time-format's syntax %{variable|d3-time-format}, for example "Day: %{2019-01-01|%A}". https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format for details on the date formatting syntax. The variables available in `hovertemplate` are the ones emitted as event data described at this link https://plotly.com/javascript/plotlyjs-events/#event-data. Additionally, every attributes that can be specified per-point (the ones that are `arrayOk: true`) are available. variable `norm` Anything contained in tag `&lt;extra&gt;` is displayed in the secondary box, for example "&lt;extra&gt;{fullData.name}&lt;/extra&gt;". To hide the secondary box completely, use an empty tag `&lt;extra&gt;&lt;/extra&gt;`.</param>
        /// <param name="XHoverFormat">Sets the hover text formatting rulefor `x` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `xaxis.hoverformat`.</param>
        /// <param name="YHoverFormat">Sets the hover text formatting rulefor `y` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `yaxis.hoverformat`.</param>
        /// <param name="ZHoverFormat">Sets the hover text formatting rulefor `z` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format. And for dates see: https://github.com/d3/d3-time-format/tree/v2.2.3#locale_format. We add two items to d3's date formatter: "%h" for half of the year as a decimal number as well as "%{n}f" for fractional seconds with n digits. For example, "2016-10-13 09:15:23.456" with tickformat "%H~%M~%S.%2f" would display "09~15~23.46"By default the values are formatted using `zaxis.hoverformat`</param>
        /// <param name="ValueHoverFormat">Sets the hover text formatting rulefor `value` using d3 formatting mini-languages which are very similar to those in Python. For numbers, see: https://github.com/d3/d3-format/tree/v1.4.5#d3-format.By default the values are formatted using generic number format.</param>
        /// <param name="Meta">Assigns extra meta information associated with this trace that can be used in various text attributes. Attributes such as trace `name`, graph, axis and colorbar `title.text`, annotation `text` `rangeselector`, `updatemenues` and `sliders` `label` text all support `meta`. To access the trace `meta` values in an attribute in the same trace, simply use `%{meta[i]}` where `i` is the index or key of the `meta` item in question. To access trace `meta` in layout attributes, use `%{data[n[.meta[i]}` where `i` is the index or key of the `meta` and `n` is the trace index.</param>
        /// <param name="CustomData">Assigns extra data each datum. This may be useful when listening to hover, click and selection events. Note that, "scatter" traces also appends customdata items in the markers DOM elements</param>
        /// <param name="Scene">Sets a reference between this trace's 3D coordinate system and a 3D scene. If "scene" (the default value), the (x,y,z) coordinates refer to `layout.scene`. If "scene2", the (x,y,z) coordinates refer to `layout.scene2`, and so on.</param>
        /// <param name="ColorAxis">Sets a reference to a shared color axis. References to these shared color axes are "coloraxis", "coloraxis2", "coloraxis3", etc. Settings for these shared color axes are set in the layout, under `layout.coloraxis`, `layout.coloraxis2`, etc. Note that multiple color scales can be linked to the same color axis.</param>
        /// <param name="ColorBar">Sets the colorbar of this trace</param>
        /// <param name="AutoColorScale">Determines whether the colorscale is a default palette (`autocolorscale: true`) or the palette determined by `colorscale`. In case `colorscale` is unspecified or `autocolorscale` is true, the default palette will be chosen according to whether numbers in the `color` array are all positive, all negative or mixed.</param>
        /// <param name="ColorScale">Sets the colorscale. The colorscale must be an array containing arrays mapping a normalized value to an rgb, rgba, hex, hsl, hsv, or named color string. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 'rgb(0,0,255)'], [1, 'rgb(255,0,0)']]`. To control the bounds of the colorscale in color space, use`cmin` and `cmax`. Alternatively, `colorscale` may be a palette name string of the following list: Blackbody,Bluered,Blues,Cividis,Earth,Electric,Greens,Greys,Hot,Jet,Picnic,Portland,Rainbow,RdBu,Reds,Viridis,YlGnBu,YlOrRd.</param>
        /// <param name="ShowScale">Determines whether or not a colorbar is displayed for this trace.</param>
        /// <param name="ReverseScale">Reverses the color mapping if true. If true, `cmin` will correspond to the last color in the array and `cmax` will correspond to the first color.</param>
        /// <param name="CAuto">Determines whether or not the color domain is computed with respect to the input data (here `value`) or the bounds set in `cmin` and `cmax` Defaults to `false` when `cmin` and `cmax` are set by the user.</param>
        /// <param name="CMin">Sets the lower bound of the color domain. Value should have the same units as `value` and if set, `cmax` must be set as well.</param>
        /// <param name="CMid">Sets the mid-point of the color domain by scaling `cmin` and/or `cmax` to be equidistant to this point. Value should have the same units as `value`. Has no effect when `cauto` is `false`.</param>
        /// <param name="CMax">Sets the upper bound of the color domain. Value should have the same units as `value` and if set, `cmin` must be set as well.</param>
        /// <param name="Caps">Sets the caps of this trace caps (color-coded surfaces on the sides of the visualization domain)</param>
        /// <param name="Contour">Sets the contour of this trace.</param>
        /// <param name="FlatShading">Determines whether or not normal smoothing is applied to the meshes, creating meshes with an angular, low-poly look via flat reflections.</param>
        /// <param name="HoverLabel">Sets the hover labels of this trace.</param>
        /// <param name="IsoMax">Sets the maximum boundary for iso-surface plot.</param>
        /// <param name="IsoMin">Sets the minimum boundary for iso-surface plot.</param>
        /// <param name="Lighting">Sets the Lighting of this trace.</param>
        /// <param name="LightPosition">Sets the LightPosition of this trace.</param>
        /// <param name="OpacityScale">Sets the opacityscale. The opacityscale must be an array containing arrays mapping a normalized value to an opacity value. At minimum, a mapping for the lowest (0) and highest (1) values are required. For example, `[[0, 1], [0.5, 0.2], [1, 1]]` means that higher/lower values would have higher opacity values and those in the middle would be more transparent Alternatively, `opacityscale` may be a palette name string of the following list: 'min', 'max', 'extremes' and 'uniform'. The default is 'uniform'.</param>
        /// <param name="Slices">Sets slices through the volume</param>
        /// <param name="SpaceFrame">Sets the SpaceFrame of this trace.</param>
        /// <param name="Surface">Sets the Surface of this trace.</param>
        /// <param name="UIRevision">Controls persistence of some user-driven changes to the trace: `constraintrange` in `parcoords` traces, as well as some `editable: true` modifications such as `name` and `colorbar.title`. Defaults to `layout.uirevision`. Note that other user-driven trace attribute changes are controlled by `layout` attributes: `trace.visible` is controlled by `layout.legend.uirevision`, `selectedpoints` is controlled by `layout.selectionrevision`, and `colorbar.(x|y)` (accessible with `config: {editable: true}`) is controlled by `layout.editrevision`. Trace changes are tracked by `uid`, which only falls back on trace index if no `uid` is provided. So if your app can add/remove traces before the end of the `data` array, such that the same trace has a different index, you can still preserve user-driven changes if you give each trace a `uid` that stays with it as it moves.</param>
        static member IsoSurface 
            (
                ?Name               : string,
                ?Visible            : StyleParam.Visible,
                ?ShowLegend         : bool,
                ?LegendRank         : int,
                ?LegendGroup        : string,
                ?LegendGroupTitle   : Title,
                ?Opacity            : float,
                ?Ids                : seq<#IConvertible>,
                ?X                  : seq<#IConvertible>,
                ?Y                  : seq<#IConvertible>,
                ?Z                  : seq<#IConvertible>,
                ?Value              : seq<#IConvertible>,
                ?Text               : seq<#IConvertible>,
                ?HoverText          : seq<#IConvertible>,
                ?HoverInfo          : string,
                ?HoverTemplate      : string,
                ?XHoverFormat       : string,
                ?YHoverFormat       : string,
                ?ZHoverFormat       : string,
                ?ValueHoverFormat   : string,
                ?Meta               : seq<#IConvertible>,
                ?CustomData         : seq<#IConvertible>,
                ?Scene              : StyleParam.SubPlotId,
                ?ColorAxis          : StyleParam.SubPlotId,
                ?ColorBar           : ColorBar,
                ?AutoColorScale     : bool,
                ?ColorScale         : StyleParam.Colorscale,
                ?ShowScale          : bool,
                ?ReverseScale       : bool,
                ?CAuto              : bool,
                ?CMin               : float,
                ?CMid               : float,
                ?CMax               : float,
                ?Caps               : Caps,
                ?Contour            : Contour,
                ?FlatShading        : bool,
                ?HoverLabel         : Hoverlabel,
                ?IsoMax             : float,
                ?IsoMin             : float,
                ?Lighting           : Lighting,
                ?LightPosition      : LightPosition,
                ?OpacityScale       : seq<#seq<#IConvertible>>,
                ?Slices             : Slices,
                ?SpaceFrame         : Spaceframe,
                ?Surface            : Surface,
                ?UIRevision         : seq<#IConvertible>
            ) =
                fun (volume: #Trace) -> 

                    Name                |> DynObj.setValueOpt volume "name"
                    Visible             |> DynObj.setValueOptBy volume "visible" StyleParam.Visible.convert
                    ShowLegend          |> DynObj.setValueOpt volume "showlegend"
                    LegendRank          |> DynObj.setValueOpt volume "legendrank"
                    LegendGroup         |> DynObj.setValueOpt volume "legendgroup"
                    LegendGroupTitle    |> DynObj.setValueOpt volume "legendgrouptitle"
                    Opacity             |> DynObj.setValueOpt volume "opacity"
                    Ids                 |> DynObj.setValueOpt volume "ids"
                    X                   |> DynObj.setValueOpt volume "x"
                    Y                   |> DynObj.setValueOpt volume "y"
                    Z                   |> DynObj.setValueOpt volume "z"
                    Value               |> DynObj.setValueOpt volume "value"
                    Text                |> DynObj.setValueOpt volume "text"
                    HoverText           |> DynObj.setValueOpt volume "hovertext"
                    HoverInfo           |> DynObj.setValueOpt volume "hoverinfo"
                    HoverTemplate       |> DynObj.setValueOpt volume "hovertemplate"
                    XHoverFormat        |> DynObj.setValueOpt volume "xhoverformat"
                    YHoverFormat        |> DynObj.setValueOpt volume "yhoverformat"
                    ZHoverFormat        |> DynObj.setValueOpt volume "zhoverformat"
                    ValueHoverFormat    |> DynObj.setValueOpt volume "valuehoverformat"
                    Meta                |> DynObj.setValueOpt volume "meta"
                    CustomData          |> DynObj.setValueOpt volume "customdata"
                    Scene               |> DynObj.setValueOptBy volume "scene" StyleParam.SubPlotId.convert
                    ColorAxis           |> DynObj.setValueOptBy volume "scene" StyleParam.SubPlotId.convert
                    ColorBar            |> DynObj.setValueOpt volume "colorbar"
                    AutoColorScale      |> DynObj.setValueOpt volume "autocolorscale"
                    ColorScale          |> DynObj.setValueOptBy volume "colorscale" StyleParam.Colorscale.convert
                    ShowScale           |> DynObj.setValueOpt volume "showscale"
                    ReverseScale        |> DynObj.setValueOpt volume "reversescale"
                    CAuto               |> DynObj.setValueOpt volume "cauto"
                    CMin                |> DynObj.setValueOpt volume "cmin"
                    CMid                |> DynObj.setValueOpt volume "cmid"
                    CMax                |> DynObj.setValueOpt volume "cmax"
                    Caps                |> DynObj.setValueOpt volume "caps"
                    Contour             |> DynObj.setValueOpt volume "contour"
                    FlatShading         |> DynObj.setValueOpt volume "flatshading"
                    HoverLabel          |> DynObj.setValueOpt volume "hoverlabel"
                    IsoMax              |> DynObj.setValueOpt volume "isomax"
                    IsoMin              |> DynObj.setValueOpt volume "isomin"
                    Lighting            |> DynObj.setValueOpt volume "lighting"
                    LightPosition       |> DynObj.setValueOpt volume "lightposition"
                    OpacityScale        |> DynObj.setValueOpt volume "opacityscale"
                    Slices              |> DynObj.setValueOpt volume "slices"
                    SpaceFrame          |> DynObj.setValueOpt volume "spaceframe"
                    Surface             |> DynObj.setValueOpt volume "surface"
                    UIRevision          |> DynObj.setValueOpt volume "uirevision"
                
                    volume
