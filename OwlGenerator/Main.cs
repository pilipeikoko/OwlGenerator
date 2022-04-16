using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDS.RDF;
using VDS.RDF.Ontology;

namespace OwlGenerator
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            OntologyService service = new OntologyService();

            OntologyGraph graph = new OntologyGraph();

            service.CreateClass(graph, "Vehicle");
            service.CreateSubClass(graph, "Vehicle", "Bus");
            service.CreateIndividual(graph, "Vehicle", "Bmw");

            graph.SaveToFile("c:\\users\\pilip\\source\\repos\\OwlGenerator\\test.rdf");
        }
    }
}
