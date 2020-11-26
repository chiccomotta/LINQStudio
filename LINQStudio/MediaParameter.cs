using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LINQStudio
{
    public class MediaParameter
    {
        [DisplayName("parameters.flowType")]
        public string FlowType { get; set; }
        
        [DisplayName("parameters.fase")]
        public string Fase { get; set; }

        [DisplayName("altreptz.autostrada.attributo.codice")]
        public int AutostradaCodice { get; set; }
    }
}
