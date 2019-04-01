open System
open Model
open Suave

[<EntryPoint>]
let main argv =
    let blog = Utils.getBlog()
    startWebServer defaultConfig (Successful.OK blog.Url)

    0 // return an integer exit code
