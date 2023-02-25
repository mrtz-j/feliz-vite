module App

open Feliz

[<ReactComponent>]
let Counter () =
    let count, setCount = React.useState 0

    Html.div
        [
            prop.children
                [
                    Html.h1 count
                    Html.button
                        [
                            prop.text "Increment"
                            prop.onClick (fun _ -> setCount (count + 1))
                            prop.classes [ "btn btn-primary" ]
                        ]
                    Html.button
                        [
                            prop.text "Decrement"
                            prop.onClick (fun _ -> setCount (count - 1))
                            prop.classes [ "btn btn-primary" ]
                        ]
                ]
        ]


[<ReactComponent>]
let App () = React.fragment [ Counter() ]

open Browser.Dom

let root = ReactDOM.createRoot (document.getElementById "root")

root.render (App())
