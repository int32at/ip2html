ip2html
=======

ip2html generates HTML code based on an InfoPath View. It works server side -> that means your form must have Code Behind. If this is not applicable (i.e. no-code solution) you can also use this code in a Web Service. 

#Usage
Build the solution and include int32.Utils.InfoPath2Html.dll in your InfoPath Project and then use the following code in your FormCode.cs

```c#

//get the current view name
var viewName = this.CurrentView.ViewInfo.Name.Replace(" ", string.Empty) + ".xsl";

//load data
var data = new XmlDocument();
data.LoadXml(this.MainDataSource.CreateNavigator().InnerXml);

//load stylesheet
var styleSheet = new XmlDocument();
using (var stream = this.Template.OpenFileFromPackage(viewName))
  styleSheet.Load(stream);

//generate the html
var html = InfoPath2Html.Generate(data, styleSheet);

//proceed html; for example, convert it to pdf...
//...
//..
//.
 
```
