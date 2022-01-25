Funcionalidade: Deposito em conta corrente
					operacoes de deposito em conta
					do tipo conta corrente

Cenário: Deposito Realizado Com Sucesso
	Dado Uma conta corrente ativa
	Quando O valor for depositado
	E o valor é superior a zero
	Então Receberei uma mensagem de deposito realizado com sucesso

Cenário: Deposito com valor negativo ou igual a zero
	Dado Uma conta corrente ativa
	Quando O valor for depositado
	E O valor é negativo ou igual zero
	Então Receberei uma mensagem de falha na transacao

Cenário: Deposito com valor acima do limite
	Dado Uma conta corrente ativa
	Quando O valor for depositado
	E O valor é acima do limite
		| Valor   |
		| 1000000 |
	Então Receberei uma mensagem de valor acima do limite