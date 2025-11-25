module App

open Feliz
open Feliz.JSX

[<ReactComponent(true)>]
let private OtherCounter () =
    let counter, setCounter = React.useState 0

    let ChildList =
        if counter = 0 then
            Html.jsx $"""
            <li>No items</li>
            """
        else
            React.Fragment [
                for i in 1..counter do
                    Html.jsx $"""
                        <li key={i} id={sprintf "item-%d" i}>Item {i}</li>
                    """
            ]
    Html.jsx
        $"""
        <div class="flex bg-blue-50">
            <h1>Counter - Reactivity Test</h1>
            <button  class="px-3 py-1 border rounded-md" onClick={fun _ -> setCounter(counter + 1) } >Increment</button>
            <ul>
                {ChildList}
            </ul>
        </div>
    """

[<ReactComponent>]
let private Counter () =
    let count, setCount = React.useState 1

    Html.div [
        prop.classes ["flex items-center bg-blue-50"]
        prop.children [
            Html.button [
                prop.text "Increment"
                prop.onClick (fun _ -> setCount (count + 1))
                prop.classes ["px-3 py-1 border rounded-md"]
            ]
            Html.h1 [
                prop.text count
                prop.classes ["w-12 text-center mx-2"]
            ]
            Html.button [
                prop.text "Decrement"
                prop.onClick (fun _ -> setCount (count - 1))
                prop.classes ["px-3 py-1 border rounded-md"]
            ]
        ]
    ]

[<ReactComponent>]
let App () = React.Fragment [ Counter(); OtherCounter()]

open Browser.Dom
let root = ReactDOM.createRoot (document.getElementById "root")
root.render (App ())