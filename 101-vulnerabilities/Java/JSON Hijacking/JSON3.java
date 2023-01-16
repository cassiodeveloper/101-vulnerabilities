PrintWriter out = response.getWriter();
response.setContentType("application/json");
JSONArray resultArray = new JSONArray();
if (authenticated) {
	ResultSet rs = getSecurityQuestions(userId);
	while (rs.next()) {
		JSONObject obj = new JSONObject();
		obj.put("SecurityQuestion", rs.getString("SecurityQuestion"));
		obj.put("SecurityAnswer", rs.getString("SecurityAnswer"));
		resultArray.put(obj);
	}
}
out.print("for(;;);"+resultArray.toString());