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

Um invasor pode criar uma página da Web maliciosa e, por meio de engenharia social, conseguir que um usuário a acesse. Se esse usuário usar um navegador desatualizado e estiver conectado ao aplicativo vulnerável, o invasor poderá recuperar o conteúdo de objetos JSON, ignorando o SOP e lendo o conteúdo desses objetos e qualquer informação confidencial nele contida. Observe que, embora esse problema geralmente se aplique a navegadores desatualizados, herdados e obsoletos, problemas de sequestro de JSON também surgem periodicamente em navegadores mais modernos.

# Porquê :question:

O seguinte é necessário para que o aplicativo seja vulnerável:
- O aplicativo deve estar usando autenticação baseada em cookie
- O aplicativo responde de maneira autenticada a uma solicitação GET simples
- Esses dados confidenciais são retornados como um JSON, especificamente em formato de array (entre colchetes []) e contendo objetos dentro do array
 
Ao retornar um array JSON, um invasor pode criar um site malicioso, que incorpora uma tag <code>&lt;script&gt;</code> em sua página da seguinte maneira:<code>&lt;script src="https:// example.com/path/to/vulnerable/page"&gt;&lt;/script&gt;</code>O navegador interpretará o valor retornado como um objeto, fazendo com que ele exista temporariamente no DOM da página maliciosa; porém como este objeto não é atribuído ou referenciado, ele será efêmero, e normalmente seria imediatamente descartado. Isso é semelhante a qualquer outra declaração ou valor de retorno sem uma atribuição, e a página da Web maliciosa seria incapaz de fazer referência a ela de qualquer maneira. Para realmente explorar esse problema em um navegador vulnerável, um invasor teria que ser capaz de substituir o função de protótipo para setters, que normalmente é restrita. Se o navegador for vulnerável e permitir a substituição de certos protótipos principais para setters em Javascript no contexto da página da Web, eles poderão criar um Javascript que, uma vez que uma página vulnerável seja incluída no método, um objeto iniciará a construção, acionará o setter substituído protótipos com o conteúdo do objeto JSON como valores, e um invasor poderia acessar esses valores no contexto de sua página da Web maliciosa. A partir desse ponto - acessá-los seria trivial.

# Faz direito! :bulb:

Existem vários métodos para resolver esse problema:
- Não responda com arrays JSON, pois eles são agrupados com colchetes, que imediatamente são avaliados como objetos; se necessário, envolva a matriz com um objeto externo (por exemplo, {"array":[]}) ou adicione algum tipo de prefixo para evitar esse problema
- Se necessário, responda com arrays JSON apenas para requisição POST; garantir que nenhuma informação confidencial seja retornada como uma matriz para uma solicitação GET
- Prefixe o objeto JSON com JavaScript (<code>for(;;);</code>) ou um JSON não analisável (<code>{};</code>) e, antes de processá-lo no cliente, retire este prefixo; o último fará com que a importação falhe e o primeiro fará com que a importação trave para sempre - de qualquer forma, isso impedirá que um invasor importe um objeto JSON como um script