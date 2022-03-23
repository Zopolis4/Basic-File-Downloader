# Basic File Downloader
A very basic command-line file downloader written in Cω. Technically, its written in .NET 6.0, but it also happens to be valid Cω.

I would have used WebClient (even though its "obsolete"), but HttpClient provides the easiest access to headers.

The lack of a progress bar is also due to the use of HttpClient, given that it's incredibly difficult to make a progress bar in HttpClient. I might add one later, though.
