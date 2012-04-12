using System.Text;

namespace HTTPModule
{
    public static class HeaderGenerator
    {
         public static string GenerateHeader()
         {
             var stringBuilder = new StringBuilder();
             stringBuilder.AppendLine("<script type=\"text/javascript\">");
             stringBuilder.AppendLine("//Test - Script Text Would Go Here!");
             stringBuilder.AppendLine("</script>");

             return stringBuilder.ToString();
         }
    }
}