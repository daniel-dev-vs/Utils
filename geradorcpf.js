window.onload = function () {
    function exec(){
		var arr = [],
			mult = [10,9,8,7,6,5,4,3,2],
			res = [],
			soma = 0,
			resto = 0,
			div = 0,
			dig1 = 0,
			dig2 = 0;
		
	   
		arr = retornarSequenciaAleatoria();
		res = multiplicar(9, arr, mult);
		soma = somar(9, res);	   

	    resto = restoModPorOnze(soma);
	    div = dividirPorOnze(soma);
	    dig1 = validar(resto, div);
	    soma = 0;
	  	res = [];
		
		arr.push(dig1);
		mult = [11,10,9,8,7,6,5,4,3,2];
		
		res = multiplicar(10, arr, mult);
		soma = somar(10, res);	
		
		resto = restoModPorOnze(soma);
	    div = dividirPorOnze(soma);
	    dig2 = validar(resto, div);
	    
	    arr.push(dig2);
	    var str = "";

	    for (var i = 0; i < 11; i++) {
	        str += arr[i].toString();
	    }

	    document.writeln(str);
	}		
	
	exec();
	
	function retornarSequenciaAleatoria()
	{
		var arrayInt = [];
		 for (var i = 0; i < 9; i++) {
	        arrayInt[i] = retornarIntAleatorio(0, 9);
	    }
		
		 return arrayInt;
	}
	
	function retornarIntAleatorio(min,max){  
        return Math.floor(Math.random() * (max - min) + min);
    }	
	
	function validar(resto, div){
	    if (resto < 2) {
	        return 0;
	    }

	    return 11 - resto;
	}

	function multiplicar(tamanho, arr, mult){
		var res = [];
		for (var i = 0; i < tamanho; i++){
			res.push(arr[i] * mult[i]);
		}

		return res;
	}

	function somar(tamanho, res){
		var soma = 0;

		for (var i = 0; i < tamanho; i++) {
	        soma += res[i];
	    }

		return soma;
	}

	function dividirPorOnze(soma){
		return Math.floor(soma / 11);
	}
	
	function restoModPorOnze(soma){
		return soma % 11;
	}
	
};
