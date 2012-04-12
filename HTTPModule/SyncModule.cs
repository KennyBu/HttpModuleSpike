using System;
using System.Web;
using System.Web.UI;

namespace HTTPModule
{
    public class SampleModule : IHttpModule
    {
        
        public void Init(HttpApplication app)
        {
            // register for events created by the pipeline 
            app.PostMapRequestHandler += OnPostMapRequestHandler;
        }

        private void OnPostMapRequestHandler(object sender, EventArgs e)
        {
            var page = HttpContext.Current.CurrentHandler as Page;
            if (page != null)
            {
                page.PreRenderComplete += OnPreRenderComplete;
            }
        }

        private void OnPreRenderComplete(object sender, EventArgs e)
        {
            var page = sender as Page;
            if(page != null)
                page.Header.Controls.Add(new LiteralControl(HeaderGenerator.GenerateHeader()));
        }
      
        public void Dispose() { }
    } 
}
