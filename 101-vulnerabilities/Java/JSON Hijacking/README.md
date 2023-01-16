# EN

# What can goes wrong :shit:

An attacker may craft a malicious web-page and, via social engineering, get a user to access it. If that user uses an outdated browser, and is logged in to the vulnerable application, the attacker may retrieve the contents of JSON objects, bypassing SOP and reading these objects' contents, and any sensitive information therein. Note that, while this issue generally applies to outdated, legacy and obsolete browsers, JSON hijacking issues also periodically arise in more modern browsers.

# Why :question:

The following is required for the application to be vulnerable:
- The application must be using cookie-based authentication
- The application responds in an authenticated manner to simple GET request
- This sensitive data is returned as a JSON, specifically in array form (enclosed in square [] brackets), and containing objects inside within the array
 
By returning a JSON array, an attacker may create a malicious website, which incorporates a <code>&lt;script&gt;</code> tag in their page in the following manner:<code>&lt;script src="https://example.com/path/to/vulnerable/page"&gt;&lt;/script&gt;</code>The browser will interpret the returned value as an object, causing it to temporarily exist in the malicious web-page's DOM; however since this object it is not assigned or referenced, it will be ephemeral, and would normally be immediately discarded. This is similar to any other declaration or return value without an assignment, and the malicious web-page would be unable to reference it in any way.To actually exploit this issue in a vulnerable browser, an attacker would have to be able to override the prototype function for setters, which is normally restricted. If the browser is vulnerable and does allow overwriting certain core prototypes for setters in Javascript within the web-page context, they could craft a Javascript that, once a vulnerable page is included with the  method, an object will initiate construction, trigger the overridden setter prototypes with the JSON object's contents as values, and an attacker would then be able to access these values in the context of their malicious web-page. From that point on - accessing them would be trivial.


# Do it right! :bulb:

There are multiple methods to address this issue:
- Do not respond with JSON arrays as they are wrapped with square brackets, which immediately get evaluated as objects; if required, wrap the array with an external object (e.g. {"array":[]}) or add some sort of prefix to prevent this issue
- If required, respond with JSON arrays only to POST request; ensure no sensitive information is ever returned as an array to a GET request
- Prefix the JSON object with either JavaScript (<code>for(;;);</code>) or an unparseable JSON (<code>{};</code>) , and, before processing it on the client, strip this prefix; the latter will cause importation to fail, and the former will cause importation to hang forever - either way, this will prevent an attacker from importing a JSON object as a script


# PT

# Que merda pode dar :shit:


# Porquê :question:


# Faz direito! :bulb: