# Que merda pode dar

An attacker could run arbitrary code on the application server host. Depending on the application’s OS permissions,these could include:
- Database access, such as reading or modifying sensitive data;
- File actions (read / create / modify / delete);
- Changing the website;
- Open a network connection to the attacker’s server;
- Decrypt secret data using the application's encryption keys;
- Start and stop system services;
- Complete server takeover.

# Porquê

The application performs some action by creating and running code that includes untrusted data, which might be under control of a malicious user. If the data contains malicious code, the executed code could contain system-level activities engineered by an attacker, as though the attacker were running code directly on the application server.

# Faz direito!

The application should not compile, execute, or evaluate any untrusted code from any external source, including user input, uploaded files, or a database. If it is absolutely necessary to include external data in dynamic execution, it is permissible to pass the data as parameters to the code, but do not execute user data directly.  If it is necessary to pass untrusted data to dynamic execution, enforce very strict data validation. For example, accept only integers between certain values.Validate all input, regardless of source. Validation should be based on a whitelist: accept only data fitting a specified structure, rather than reject bad patterns. Parameters should be limited to an allowed character set, and non-validated input should be dropped. In addition to characters, check for:
## Data 
- type
- Size
- Range
- Format
- Expected values

If possible, always prefer to whitelist known and trusted input instead of comparing to a blacklist.
Configure the application to run using a restricted user account that has no unnecessary privileges.

If possible, isolate all dynamic execution to use a separate, dedicated user account that has privileges only for the specific operations and files used by dynamic execution, according to the Principle of Least Privilege.

If dynamic execution is necessary, run all dynamic code in an external process, and pass the external data as a parameter to the process.

Alternatively, it is possible to perform dynamic execution of code in an isolated sandbox, such as .NET’s <code>AppDomain</code> with <code>Evidence</code> to restrict its <code>PermissionSet</code> to the minimum, using <code>SecurityManager.GetStandardSandbox()</code>. (Note that this can never provide complete protection from sandbox exploits, and should be avoided if possible.)