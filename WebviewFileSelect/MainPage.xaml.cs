namespace WebviewFileSelect
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            testWebView.Source = new HtmlWebViewSource
            {
                Html = source
            };
        }

         private string source = @"
<html>
	<script>
	function listFiles() {
		var selectedFiles = document.getElementById(""fileSelect"").files;
		var list = document.getElementById(""fileList"");

		var inner = """";

		for(file of selectedFiles) {
			inner += ""<li>"" + file.name + ""</li>"";
		}	

		list.innerHTML = inner;
	}
	</script>

	<body>
	
		<label for=""files"">Select files:</label>
		<input type='file' id=""fileSelect"" multiple/>
		<br/>
		<br/>
		<input value=""Update"" type=""button"" onclick='listFiles()'/>
		<ul id=""fileList""/> 			
	</body>
</html>
";
    }
}
