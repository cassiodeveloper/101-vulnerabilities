// Send jQuery AJAX Request via POST with Password in URL

var url = `/login?username=${username}&password=${password}`;
$.ajax({url: url , method: 'POST', data : {username: username, password : password}, success: function(result){
    // Handle Response
});