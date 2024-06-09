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
              
              if(element.ElementSchemaType is XmlSchemaComplexType complexType)
                {

                    if(complexType.Particle is XmlSchemaSequence sequence)
                    {

                        foreach(XmlSchemaObject item in sequence.Items)
                        {
                            if(item is XmlSchemaElement element2)
                            {
                                var formElement = new FormElement
                                {

                                    Name = element2.Name,
                                    Type = element2.SchemaTypeName.Name
                                };
                                elements.Add(formElement);
                            }
                        }
                    }
                }
             
            }
        }

        return elements;
    }
}