using System;
using System.Web;
using System.Web.UI;

namespace HTTPModule
{
    public class SampleModule : IHttpModule
    {
        DateTime beginrequest;
        
        public void Init(HttpApplication app)
        {
            // register for events created by the pipeline 
            app.BeginRequest += OnBeginRequest;
            app.EndRequest += OnEndRequest;
            app.PostMapRequestHandler += OnPostMapRequestHandler;
         
        }

        private void OnPostMapRequestHandler(object sender, EventArgs e)
        {
            HttpContext context = ((HttpApplication)sender).Context;
            Page page = HttpContext.Current.CurrentHandler as Page;
            if (page != null)
            {
                page.PreRenderComplete += OnPreRenderComplete;
            }
        }

        private void OnPreRenderComplete(object sender, EventArgs e)
        {
            var page = (Page)sender;
            page.Header.Controls.Add(new LiteralControl(HeaderGenerator.GenerateHeader()));
        }


        public void Dispose() { }
        public void OnBeginRequest(object o, EventArgs args)
        {
            // obtain the time of the current request 
            beginrequest = DateTime.Now;
        }
        public void OnEndRequest(object o, EventArgs args)
        {
            // get the time elapsed for the request 
            TimeSpan elapsedtime = DateTime.Now - beginrequest;
            // get access to application object and the context object 
            var app = (HttpApplication) o;
            var ctx = app.Context;
            
            // add header to HTTP response 
            ctx.Response.AppendHeader("ElapsedTime", elapsedtime.ToString());

            ctx.Response.Write(elapsedtime.ToString());

            
        }
    } 


}
