const http = new XMLHttpRequest()

http.open("GET", "http://3.92.252.3/BlindWeb/MYSQL_DB_TO_JSON.asp")
http.send()
// alert(http.responseText)
var temp = new Array()
var block_urls = new Array()
var except_urls = new Array()
var list1 = new Array()
var list2 = new Array()

http.onreadystatechange = function(temp) 
{
    if(http.readyState == 4)
    {
        alert("!")

        temp = http.responseText
        alert(temp)
        temp = temp.replace('<script>', "")
        temp = temp.replace('var arr1 = new Array();',"")
        temp = temp.replace('var arr2 = new Array();',"")
        temp = temp.replace('var i = 0;',"")
        temp = temp.replace('var j = 0;',"")
        temp = temp.replace('</script>', "")
        button = 0
        start = 0
        end = 0
        white = temp.indexOf('arr2[i++]')
        i = 0
        while(button != 1)
        {
            start = temp.indexOf('"',end+1)
            end = temp.indexOf(';',end+1)
            if(end < white)
            {
                if(temp[start+1] != 'h')
                {
                    button = 1
                }
                if(temp[start+1] == 'h')
                {
                    list1[i] = temp.substring(start+1,end-1)
                // alert(list[i])
                }
                i = i + 1
            }
        }
        while(button != 2)
        {
            start = temp.indexOf('"',end+1)
            end = temp.indexOf(';',end+1)
            if(end > white)
            {
                if(temp[start+1] != 'h')
                {
                    button = 2
                }
                if(temp[start+1] == 'h')
                {
                    list2[i] = temp.substring(start+1,end-1)
                }
                i = i + 1
            }
        }
        // alert(temp)
        // alert(list.length)
        for(var i=0;i<list1.length;i++)
        {
            // alert(i)
            block_urls[i] = list1[i]
            // alert(block_urls[i])
        }
        for(var i=0;i<list2.length;i++)
        {
            // alert(i)
            except_urls[i] = list2[i]
        }

        for(var i=0;i<list2.length;i++)
        {
            // alert(except_urls[i])
        if(except_urls[i] == undefined)
        {
            except_urls.shift();
        }

        }
        // alert(except_urls)


    // alert(block_urls[0])
    // var block_url = ["https://www.youtube.com/?gl=KR&hl=ko"
    // ,"http://www.wwwwwwww.com"
    // ,"http://sowarning.com"
    // ,"https://www.naver.com"]

        var regexp1 = new RegExp(/porn/,'gi');
        var i = 0
        var Redirector = function (from, to)
        {
            this.from = from;
            this.to = to;

            this.redirectOnMatch = function (request)
            {
                // alert(block_urls[0])
                var home = new RegExp(/^http:\/\/3\.92\.252\.3\/BlindWeb/);
                if(home.test(request.url))
                    return;
                    
                for(var i = 0; i <except_urls.length; i++)
                {
                    var regexp = new RegExp(except_urls[i],'gi');
                    if( regexp.test(request.url) == true)
                    {
                        return;
                    }
                }

                for(var i = 0; i <block_urls.length; i++)
                {
                    var regexp = new RegExp(block_urls[i],'gi');
                    if( regexp1.test(request.url) == true)
                    {
                        var DES = "http://3.92.252.3/BlindWeb/blockedSite.asp?burl=" + request.url
                        return { redirectUrl: DES };
                    }
                    if( regexp.test(request.url) == true)
                    {
                        var DES = "http://3.92.252.3/BlindWeb/blockedSite.asp?burl=" + request.url
                        return { redirectUrl: DES };
                    }
                }        
            };
        };


        var TO = "http://3.92.252.3/BlindWeb/blockedSite.asp" 


        chrome.webRequest.onBeforeRequest.addListener(
            function (details) 
            {
                // alert(i)
                var FROM = block_urls[i]
                var redirector = new Redirector(FROM, TO);
                return redirector.redirectOnMatch(details);
            },
            {
                urls: ["<all_urls>"]
            },
            ["blocking"]
        );
    }
}


