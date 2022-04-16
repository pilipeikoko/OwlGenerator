using System;
using System.Collections.Generic;
using System.Linq;
using VDS.RDF;
using VDS.RDF.Ontology;
using VDS.RDF.Parsing;
using VDS.RDF.Query;
using static System.String;

namespace OwlGenerator
{
    public class OntologyService
    {
        private static string DefaultLink = "http://my.valeksdelal.meeew/";

        public OntologyClass CreateClass(OntologyGraph graph, string name)
        {
            var generatedClass
                = graph.CreateOntologyClass(UriFactory.Create($"{DefaultLink}/{name}"));

            generatedClass.AddType(UriFactory.Create(OntologyHelper.OwlClass));
            generatedClass.AddLabel(name, "en");

            return generatedClass;
        }

        public IUriNode Create(OntologyGraph graph, string name)
        {
            var generatedClass
                = graph.CreateUriNode(UriFactory.Create($"{DefaultLink}/{name}"));

            return generatedClass;
        }

        public OntologyClass CreateSubClass(OntologyGraph graph, string superClassName, string name)
        {
            var generatedClass
                = graph.CreateOntologyClass(UriFactory.Create($"{FindNode(graph, superClassName)}/{name}"));

            generatedClass.AddType(UriFactory.Create(OntologyHelper.OwlClass));
            generatedClass.AddLabel(name, "en");
            generatedClass.AddSuperClass(FindNode(graph, superClassName));

            return generatedClass;
        }

        public Individual CreateIndividual(OntologyGraph graph, string className, string name)
        {
            var generatedClass = graph.CreateIndividual(Create(graph, className + "/" + name), FindUriNode(graph, className));

            generatedClass.AddLabel(name, "en");

            return generatedClass;
        }

        private Uri FindNode(OntologyGraph graph, string name)
        {
            var node = graph.Nodes.Where(x => x.NodeType == NodeType.Uri).Select(x => (UriNode) x).ToList();

            return node.FirstOrDefault(x => x.Uri.ToString().Equals(DefaultLink + "/" + name))?.Uri;
        }

        private UriNode FindUriNode(OntologyGraph graph, string name)
        {
            var node = graph.Nodes.Where(x => x.NodeType == NodeType.Uri).Select(x => (UriNode) x).ToList();

            return node.FirstOrDefault(x => x.Uri.ToString().Equals(DefaultLink + "/" + name));
        }

        public void DeleteClass(OntologyGraph g, string nodeFullPath)
        {
            var triples = g.Triples
                .Where(x => x.Object.NodeType == NodeType.Uri)
                .Select(x => (x, (UriNode) x.Object))
                .Where(y => y.Item2.Uri.AbsoluteUri.Contains(nodeFullPath))
                .Select(x => x.x)
                .ToList();

            var triples2 = g.Triples
                .Where(x => x.Subject.NodeType == NodeType.Uri)
                .Select(x => (x, (UriNode) x.Subject))
                .Where(y => y.Item2.Uri.AbsoluteUri.Contains(nodeFullPath))
                .Select(x => x.x)
                .ToList();


            g.Retract(triples);
            g.Retract(triples2);
        }

        public void UpdateUriNode(OntologyGraph graph, string parent, string name, string oldName)
        {
            CreateSubClass(graph, parent, name);
            UpdateChildren(graph, parent, name, oldName);
        }

        private void UpdateChildren(OntologyGraph graph, string parent, string name, string oldName)
        {
            var nodes = graph.Nodes
                .Where(x => x.NodeType == NodeType.Uri)
                .Select(x => (UriNode) x)
                .Where(x => x.Uri.AbsoluteUri.Contains(FindNode(graph, parent).AbsoluteUri + "/" + oldName))
                .ToList();

            foreach (var node in nodes)
            {
                DeleteClass(graph, node.Uri.AbsoluteUri);
            }

            nodes = graph.Nodes
                .Where(x => x.NodeType == NodeType.Uri)
                .Select(x => (UriNode) x)
                .Where(x => x.Uri.AbsoluteUri.Contains(FindNode(graph, parent).AbsoluteUri + "/" + oldName))
                .ToList();

            foreach (var node in nodes)
            {
                CreateClass(graph, node.Uri.AbsoluteUri.Replace(oldName, name));
            }
        }

        public List<string> GetNodes(OntologyGraph graph)
        {
            var nodes = graph.Nodes
                .Where(x => x.NodeType == NodeType.Uri)
                .Select(x => (UriNode) x)
                .Select(x => x.Uri.AbsoluteUri.Replace(DefaultLink, Empty))
                .Where(x => graph.Triples
                    .Any(y => (y.Object.NodeType == NodeType.Uri && ((UriNode) y.Object).Uri.AbsoluteUri.Contains(x))
                              || (y.Subject.NodeType == NodeType.Uri &&
                                  ((UriNode) y.Subject).Uri.AbsoluteUri.Contains(x))))
                .ToList();


            return nodes.OrderBy(x=>x).ToList();
        }

        public object ExecuteQuery(OntologyGraph graph, string text)
        {
            SparqlParameterizedString queryString = new SparqlParameterizedString();

            queryString.CommandText = text;


            SparqlQueryParser parser = new SparqlQueryParser();
            SparqlQuery query = parser.ParseFromString(queryString);

            var result = graph.ExecuteQuery(query);

            return result;
        }
    }
}