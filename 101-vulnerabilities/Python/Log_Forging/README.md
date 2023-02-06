# EN

# What can goes wrong :shit:
An attacker could engineer audit logs of security-sensitive actions and lay a false audit trail, potentially implicating an innocent user or hiding an incident.

# Why :question:
The application writes audit logs upon security-sensitive actions. Since the audit log includes user input that is neither checked for data type validity nor subsequently sanitized, the input could contain false information made to look like legitimate audit log data.

# Do it right! :bulb:
Validate all entries, regardless of source. Validation should be based on a whitelist: only accept data that fits a specified structure, rather than rejecting bad patterns. Check:
- DataType
- Size
- Range
- Format 
- Expected Values
- Validation does not replace encoding. Fully encode all dynamic data, regardless of source, before incorporating it into records. 
- Use a secure logging mechanism.

# PT

# Que merda pode dar :shit:
Um invasor pode criar logs de auditoria de ações sensíveis à segurança e estabelecer uma trilha de auditoria falsa, possivelmente envolvendo um usuário inocente ou ocultando um incidente.

# Porquê :question:
O aplicativo grava logs de auditoria em ações sensíveis à segurança. Uma vez que o log de auditoria inclui entradas do usuário que não são verificadas quanto à validade do tipo de dados nem posteriormente sanitizadas, a entrada pode conter informações falsas feitas para parecerem dados de log de auditoria legítimos.

# Faz direito! :bulb:
Valide todas as entradas, independentemente da fonte. A validação deve ser baseada em uma lista de permissões: aceite apenas dados que se encaixem em uma estrutura especificada, em vez de rejeitar padrões ruins. Verifique:
- Tipo de dados
- Tamanho
- Intervalo
- Formato
- Valores esperados 
- A validação não substitui a codificação. Codifique totalmente todos os dados dinâmicos, independentemente da origem, antes de incorporá-los aos logs.
- Use um mecanismo de log seguro.