// Send XHR via GET with Password in URL

var url = `/login?username=${username}&password=${password}`;
var xhr = new XMLHttpRequest();
xhr.onreadystatechange = function() {
	if (this.readyState == 4 && this.status == 200) {
		// Handle Response
	}
};
xhr.open("GET", url, true); // Method is immaterial; the password is sent in the URL for both GET and POST
xhr.send();