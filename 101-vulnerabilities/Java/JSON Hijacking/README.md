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

Um invasor pode criar uma p??gina da Web maliciosa e, por meio de engenharia social, conseguir que um usu??rio a acesse. Se esse usu??rio usar um navegador desatualizado e estiver conectado ao aplicativo vulner??vel, o invasor poder?? recuperar o conte??do de objetos JSON, ignorando o SOP e lendo o conte??do desses objetos e qualquer informa????o confidencial nele contida. Observe que, embora esse problema geralmente se aplique a navegadores desatualizados, herdados e obsoletos, problemas de sequestro de JSON tamb??m surgem periodicamente em navegadores mais modernos.

# Porqu?? :question:

O seguinte ?? necess??rio para que o aplicativo seja vulner??vel:
- O aplicativo deve estar usando autentica????o baseada em cookie
- O aplicativo responde de maneira autenticada a uma solicita????o GET simples
- Esses dados confidenciais s??o retornados como um JSON, especificamente em formato de array (entre colchetes []) e contendo objetos dentro do array
 
Ao retornar um array JSON, um invasor pode criar um site malicioso, que incorpora uma tag <code>&lt;script&gt;</code> em sua p??gina da seguinte maneira:<code>&lt;script src="https:// example.com/path/to/vulnerable/page"&gt;&lt;/script&gt;</code>O navegador interpretar?? o valor retornado como um objeto, fazendo com que ele exista temporariamente no DOM da p??gina maliciosa; por??m como este objeto n??o ?? atribu??do ou referenciado, ele ser?? ef??mero, e normalmente seria imediatamente descartado. Isso ?? semelhante a qualquer outra declara????o ou valor de retorno sem uma atribui????o, e a p??gina da Web maliciosa seria incapaz de fazer refer??ncia a ela de qualquer maneira. Para realmente explorar esse problema em um navegador vulner??vel, um invasor teria que ser capaz de substituir o fun????o de prot??tipo para setters, que normalmente ?? restrita. Se o navegador for vulner??vel e permitir a substitui????o de certos prot??tipos principais para setters em Javascript no contexto da p??gina da Web, eles poder??o criar um Javascript que, uma vez que uma p??gina vulner??vel seja inclu??da no m??todo, um objeto iniciar?? a constru????o, acionar?? o setter substitu??do prot??tipos com o conte??do do objeto JSON como valores, e um invasor poderia acessar esses valores no contexto de sua p??gina da Web maliciosa. A partir desse ponto - acess??-los seria trivial.

# Faz direito! :bulb:

Existem v??rios m??todos para resolver esse problema:
- N??o responda com arrays JSON, pois eles s??o agrupados com colchetes, que imediatamente s??o avaliados como objetos; se necess??rio, envolva a matriz com um objeto externo (por exemplo, {"array":[]}) ou adicione algum tipo de prefixo para evitar esse problema
- Se necess??rio, responda com arrays JSON apenas para requisi????o POST; garantir que nenhuma informa????o confidencial seja retornada como uma matriz para uma solicita????o GET
- Prefixe o objeto JSON com JavaScript (<code>for(;;);</code>) ou um JSON n??o analis??vel (<code>{};</code>) e, antes de process??-lo no cliente, retire este prefixo; o ??ltimo far?? com que a importa????o falhe e o primeiro far?? com que a importa????o trave para sempre - de qualquer forma, isso impedir?? que um invasor importe um objeto JSON como um script