// Services/XsdParser.cs
using System.Collections.Generic;
using System.Xml.Schema;

public class XsdParser
{
    public List<FormElement> Parse(string xsdFilePath)
    {

        var elements = new List<FormElement>();
        var schemaSet = new XmlSchemaSet();
        schemaSet.Add("", xsdFilePath);
        schemaSet.Compile();

        foreach (XmlSchema schema in schemaSet.Schemas())
        {
            foreach (XmlSchemaElement element in schema.Elements.Values)
            {
                var formElement = new FormElement
                {
                    Name = element.Name,
                    Type = element.SchemaTypeName.Name
                };
                elements.Add(formElement);
            }
        }

        return elements;
    }
}