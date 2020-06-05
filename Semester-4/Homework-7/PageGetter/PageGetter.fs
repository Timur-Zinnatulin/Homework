module PageGetter

open System.Net
open System.IO
open System.Text.RegularExpressions

/// Downloads the page and all subpages by given URL
let downloadPages url =
    
    /// Downloads page with given URL
    let fetchUrlAsync (url : string) =
        async {
            try
                let request = WebRequest.Create(url)
                use! response = request.AsyncGetResponse()
                use stream = response.GetResponseStream()
                use reader = new StreamReader(stream)
                let html = reader.ReadToEnd()
                do printfn "%s --- %d" url html.Length
                
                return Some html
            with
                | _ ->
                    do printfn "%s is not available!" url
                    return None
        }

    /// Downloads the page and all subpages
    let download (page : string) =
        let regex = Regex(
                        "<a href\s*=\s*\"?(https?://[^\"]+)\"?\s*>",
                        RegexOptions.IgnoreCase)
        let matches = regex.Matches(page)
        let nextPages = [for url in matches ->
                            url.Groups.[1].Value |> fetchUrlAsync]
        Async.Parallel nextPages |> Async.RunSynchronously |> Array.toList

    let initPage = url |> fetchUrlAsync |> Async.RunSynchronously

    match initPage with
    | None -> [None]
    | Some page ->
        initPage :: download page