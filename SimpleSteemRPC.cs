/*
Copyright (c) 2018 Thomas Kaufmann

Permission is hereby granted, free of charge, to any person obtaining a
copy of this software and associated documentation files (the "Software"),
to deal in the Software without restriction, including without limitation the
rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
sell copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF
ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO
THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT
SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR
ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN
ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE
OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace SteemAPI
{
    class SimpleSteemRPC
    {
        private Uri mURI;

        public SimpleSteemRPC(string uri = "https://api.steemit.com")
        {
            mURI = new Uri(uri);
        }

        public string Transaction(string method, ArrayList parameter = null)
        {
            Task<string> t = SendReceive(method, parameter);
            t.Wait();
            return t.Result;
        }

        public string FormatJSON(string response)
        {
            StringBuilder sb = new StringBuilder();
            char c;
            int space = 0;
            for (int i = 0; i < response.Length; i++)
            {
                c = response[i];
                if (c == '{')
                {
                    sb.Append(c);
                    sb.Append(System.Environment.NewLine);
                    space += 2;
                    sb.Append(' ', space);
                }
                else if (c == '}')
                {
                    sb.Append(System.Environment.NewLine);
                    space -= 2;
                    sb.Append(' ', space);
                    sb.Append(c);
                }
                else if (c == ',')
                {
                    sb.Append(c);
                    sb.Append(System.Environment.NewLine);
                    sb.Append(' ', space);
                }
                else sb.Append(c);
            }
            return sb.ToString();
        }

        private string Request2JSON(string method, ArrayList parameter)
        {
            StringBuilder sb = new StringBuilder("{\"jsonrpc\":\"2.0\",\"method\":\"" + method + "\",");
            if (parameter != null)
            {
                sb.Append("\"params\":[");
                for (int i = 0; i < parameter.Count; i++)
                {
                    if (parameter[i] is ArrayList)
                    {
                        sb.Append("[");
                        for (int j = 0; j < ((ArrayList)parameter[i]).Count; j++)
                        {
                            if (((ArrayList)parameter[i])[j] is string)
                            {
                                sb.Append('\"');
                                sb.Append(((ArrayList)parameter[i])[j]);
                                sb.Append('\"');

                            }
                            else sb.Append(((ArrayList)parameter[i])[j].ToString());
                            if (j < ((ArrayList)parameter[i]).Count - 1) sb.Append(',');
                        }
                        sb.Append("]");
                    }
                    else if (parameter[i] is string)
                    {
                        string s = (string)parameter[i];
						if (s != "")
						{
							if (s[0] == '{') sb.Append(s);
							else sb.Append("\"" + s + "\"");
						}
						else sb.Append("\"" + s + "\"");
                    }
                    else sb.Append(parameter[i].ToString());
                    if (i < parameter.Count - 1) sb.Append(',');
                }
                sb.Append("],");
            }
            sb.Append("\"id\":1}");
            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

        private async Task<string> SendReceive(string method, ArrayList parameter = null)
        {
            char[] buf = new char[2048];
            string response = string.Empty;
            string json = Request2JSON(method, parameter);
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(mURI);
                byte[] send = Encoding.UTF8.GetBytes(json);
                webRequest.Method = "POST";
                webRequest.ContentLength = send.Length;
                using (Stream writeStream = webRequest.GetRequestStream())
                {
                    writeStream.Write(send, 0, send.Length);
                }
                using (WebResponse webResponse = webRequest.GetResponse())
                {
                    using (Stream readStream = webResponse.GetResponseStream())
                    {
                        using (StreamReader sr = new StreamReader(readStream))
                        {
                            response = await sr.ReadToEndAsync();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                response = e.Message;
            }
            return response;
        }
    }
}
