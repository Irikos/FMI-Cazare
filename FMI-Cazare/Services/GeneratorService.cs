using Microsoft.AspNetCore.NodeServices;
using System.Threading.Tasks;

namespace FMI_Cazare.Services
{
    public class GeneratorService

    {
        private readonly INodeServices nodeServices;

        public GeneratorService(INodeServices _nodeServices) {
            nodeServices = _nodeServices;
        }

        public async Task<byte[]> HtmlToPdfAsync(string html)
        {
            return await nodeServices.InvokeAsync<byte[]>("./Services/NodePdfService", html);
        }
    }
}
