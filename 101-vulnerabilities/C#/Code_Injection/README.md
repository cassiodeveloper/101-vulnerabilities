# EN
# What can goes wrong :shit:

An attacker could run arbitrary code on the application server host. Depending on the application’s OS permissions,these could include:
- Database access, such as reading or modifying sensitive data;
- File actions (read / create / modify / delete);
- Changing the website;
- Open a network connection to the attacker’s server;
- Decrypt secret data using the application's encryption keys;
- Start and stop system services;
- Complete server takeover.

# Why :question:

The application performs some action by creating and running code that includes untrusted data, which might be under control of a malicious user. If the data contains malicious code, the executed code could contain system-level activities engineered by an attacker, as though the attacker were running code directly on the application server.

# Do it right! :bulb:

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

# PT
# Que merda pode dar :shit:

Um invasor pode executar código arbitrário no host do servidor de aplicativos. Dependendo das permissões do sistema operacional do aplicativo, elas podem incluir:

- Acesso ao banco de dados, como leitura ou modificação de dados confidenciais;
- Ações de arquivo (ler/criar/modificar/excluir);
- Alteração do site;
- Abrir uma conexão de rede com o servidor do invasor;
- Descriptografar dados secretos usando as chaves de criptografia do aplicativo;
- Iniciar e parar os serviços do sistema;
- Aquisição completa do servidor.

# Porquê :question:

O aplicativo executa alguma ação criando e executando código que inclui dados não confiáveis, que podem estar sob o controle de um usuário mal-intencionado. Se os dados contiverem código mal-intencionado, o código executado poderá conter atividades no nível do sistema projetadas por um invasor, como se o invasor estivesse executando o código diretamente no servidor de aplicativos.

# Faz direito! :bulb:

O aplicativo não deve compilar, executar ou avaliar qualquer código não confiável de qualquer fonte externa, incluindo entrada do usuário, arquivos carregados ou um banco de dados. Se for absolutamente necessário incluir dados externos na execução dinâmica, é permitido passar os dados como parâmetros para o código, mas não execute os dados do usuário diretamente. Se for necessário passar dados não confiáveis para execução dinâmica, imponha uma validação de dados muito rigorosa. Por exemplo, aceite apenas números inteiros entre determinados valores. Valide todas as entradas, independentemente da origem. A validação deve ser baseada em uma lista de permissões: aceite apenas dados que se encaixem em uma estrutura especificada, em vez de rejeitar padrões ruins. Os parâmetros devem ser limitados a um conjunto de caracteres permitido e a entrada não validada deve ser descartada. Além dos caracteres, verifique:
## Dados
- tipo
- Tamanho
- Alcance
- Formato
- Valores esperados

Se possível, sempre prefira inserir entradas conhecidas e confiáveis na lista de permissões em vez de comparar com uma lista negra.
Configure o aplicativo para ser executado usando uma conta de usuário restrita que não tenha privilégios desnecessários.

Se possível, isole toda a execução dinâmica para usar uma conta de usuário separada e dedicada que tenha privilégios apenas para as operações e arquivos específicos usados pela execução dinâmica, de acordo com o Princípio do Menor Privilégio.

Se a execução dinâmica for necessária, execute todo o código dinâmico em um processo externo e passe os dados externos como um parâmetro para o processo.

Como alternativa, é possível executar a execução dinâmica do código em uma caixa de proteção isolada, como <code>AppDomain</code> do .NET com <code>Evidence</code> para restringir seu <code>PermissionSet</code> ao mínimo, usando <code>SecurityManager.GetStandardSandbox()</code>. (Observe que isso nunca pode fornecer proteção completa contra explorações de sandbox e deve ser evitado, se possível.)