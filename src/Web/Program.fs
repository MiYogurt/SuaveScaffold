open System
open Model
open Suave
open Suave.Successful
open Suave.Filters
open Suave.Operators
open Suave.Sockets
open Model

let dbHandler : WebPart = (fun ctx -> 
   let blog = Utils.getBlog()
   OK blog.Url ctx
)

let router : WebPart = choose [
    GET >=> path "/" >=> OK "hello world"
    GET >=> path "/db" >=> dbHandler
    
]

[<EntryPoint>]
let main argv =
    startWebServer defaultConfig router

    0 // return an integer exit code
