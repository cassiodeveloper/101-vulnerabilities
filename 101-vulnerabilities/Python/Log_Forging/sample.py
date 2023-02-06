# Ensure you encode any special delimiter characters before writing to a log file.
Log.Write( logDetails.Replace(CRLF, @"\CRLF"));

# Ensure you encode any special delimiter characters before writing to a log file.
NSLog(@"%@", [logDetails stringByReplacingOccurrencesOfString:@"\n" withString:@"\\n"]);

# Ensure you encode any special delimiter characters before writing to a log file.
print(logDetails.stringByReplacingOccurrencesOfString("\n", withString: "\\n"))