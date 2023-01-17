# EN

# What can goes wrong :shit:

Sending sensitive information in a GET parameter as part of the URL's query string will result in this information potentially becoming cached by the browser, proxies, web-caches or be written into access logs. An attacker with access to any of the above will be able to retrieve this sensitive information.
# Why :question:

A password is being sent in a GET request as a query string parameter, either via concatenation of the password value to a URL, or by sending the password as a parameter in a GET request.  Sending parameters in a GET request is caused either by explicitly setting the method to GET, or implicitly by using a mechanism that defaults to a GET request without changing the method to another method (such as POST).
# Do it right! :bulb:
Never send sensitive information in the URL. This includes:
- Credentials
- Session or access tokens
- Personal information
- 
# PT

# Que merda pode dar :shit:
O envio de informações confidenciais em um parâmetro GET como parte da string de consulta da URL resultará na possibilidade de essas informações serem armazenadas em cache pelo navegador, proxies, caches da web ou gravadas em logs de acesso. Um invasor com acesso a qualquer um dos itens acima poderá recuperar essas informações confidenciais.

# Porquê :question:
Uma senha está sendo enviada em uma solicitação GET como um parâmetro de string de consulta, por meio da concatenação do valor da senha para uma URL ou enviando a senha como um parâmetro em uma solicitação GET. O envio de parâmetros em uma solicitação GET é causado pela configuração explícita do método como GET ou pelo uso implícito de um mecanismo cujo padrão é uma solicitação GET sem alterar o método para outro método (como POST).

# Faz direito! :bulb:
Nunca envie informações confidenciais na URL. Isso inclui:
- Credenciais
- Sessão ou tokens de acesso
- Informações pessoais