using System;

namespace WebAppSyncDiagram.Controllers
{
    public class DiagramNodeViewModel
    {
        public String Id { get; set; }
        public String IdParent { get; set; }
        public String Naam { get; set; }
        public String Path { get; set; }
        public String PathData { get; set; }
        public String Kleur { get; set; }
        public Int32 Height { get; set; }
        public Int32 Width { get; set; }
    }
}