// Send jQuery AJAX Request via POST with Password in POST Parameters

$.ajax({url: "/login" , method: 'POST', data : {username: username, password : password}, success: function(result){
    // Handle Response
});