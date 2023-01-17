// Send XHR via POST with Password in POST Parameters

var params = `username=${username}&password=${password}`;
var url = "/login";
var xhr = new XMLHttpRequest();
xhr.onreadystatechange = function() {
	if (this.readyState == 4 && this.status == 200) {
		// Handle Response
	}
  };
xhr.open("POST", url , true);
xhr.setRequestHeader('Content-type', 'application/x-www-form-urlencoded'); 
xhr.send(params);