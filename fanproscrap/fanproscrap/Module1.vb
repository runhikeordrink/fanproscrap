Imports System
Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions
Imports HtmlAgilityPack


Module Module1

    Sub Main()
        'debug line to keep console open only close on ESC
        Do Until (Console.ReadKey.Key = ConsoleKey.Escape)
            Console.Clear()
            'Call Scrape Method
            Scrape()
        Loop
    End Sub

    Private Sub Scrape()
        'Try Catch Error Check 
        Try
            'var declare url 
            Dim strURL As String = "http://zpower-intranet"
            'Inst HtmlDocument Class from htmlagilitypack lib
            Dim htmlDoc = New HtmlDocument()
            'empty var this will be to store html markup string
            Dim strOutput As String = ""
            'Inst WebResponse Class to retrieve server message
            Dim wrResponse As WebResponse
            'Inst WevRequest Class to create request to server
            Dim wrRequest As WebRequest = HttpWebRequest.Create(strURL)
            'Debug Msg
            Console.WriteLine("Extracting Webpage..." & Environment.NewLine)
            'Call Request and store response from server
            wrResponse = wrRequest.GetResponse()
            'Look through response stream 
            Using sr As New StreamReader(wrResponse.GetResponseStream())
                'Read stream
                strOutput = sr.ReadToEnd()
                ' Close and clean up the StreamReader
                sr.Close()
                'load markup body stream
                htmlDoc.LoadHtml(strOutput)
                'Scape needed Content from html doc
                Dim form = htmlDoc.DocumentNode.SelectSingleNode("//div")
                Console.WriteLine(form.ToString)
                'For Each r As HtmlNode In htmlDoc.DocumentNode.SelectNodes("//table//tr")
                '    For Each c As HtmlNode In r.SelectNodes("td")
                '        Console.WriteLine(c.InnerText.ToString)
                '    Next
                'Next
            End Using
        Catch ex As Exception
            Console.WriteLine(ex.Message, "Error")
        End Try
    End Sub

End Module
