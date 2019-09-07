#language: pt-BR
Funcionalidade: BookRoomTest
	Reservar um quarta de hotel

@mytag
Cenário: Realizar uma reserva de um quarto de hotel
	Dado que verifico se a app esta instalada no meu device
	E entro com o "username"
	E entro com o "password"
	Quando eu clicar no botão "signin"
	Dado que eu toco em "BOOK A ROOM"
	E que eu toco na cidade de "New York, United States"
	E que eu toco em "NEXT"
	E seleciono o dia de reserva "23"
	E que eu toco em "NEXT"
	E escolho o hotel "New York, United States"
	E que eu toco em "BOOK NOW"
	Então vai aparecer um alerta na tela para confirmar a reserva
	E eu seleciono "Sim"