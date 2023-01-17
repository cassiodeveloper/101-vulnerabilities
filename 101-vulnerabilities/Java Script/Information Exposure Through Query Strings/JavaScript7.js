// Send jQuery AJAX Request via GET with Password in URL

$.ajax({url: "/login" , method: 'GET', data : {username: username, password : password}, success: function(result){
    // Handle Response
});