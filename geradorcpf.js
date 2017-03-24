window.onload = function () {
    function exec(){
		var arr = [], mult = [10,9,8,7,6,5,4,3,2], res = [], soma = 0, resto = 0, div = 0, dig1 = 0, dig2 = 0;
		
	    for (var i = 0; i < 9; i++) {
	        arr[i] = getRandomInt(0, 9);
	    }

	    for (var i = 0; i < 9; i++) {
	        res.push(arr[i] * mult[i]);
	    }

	    for (var i = 0; i < 9; i++) {
	        soma += res[i];
	    }

	    resto = soma % 11;
	    div = Math.floor(soma / 11);
	    dig1 = validar(resto, div);
	    soma = 0;
	  	res = [];
		
		arr.push(dig1);
		mult = [11,10,9,8,7,6,5,4,3,2];
		
	    for (var i = 0; i < 10; i++) {        
	        res.push( arr[i] * mult[i]);
	    }
		
		for (var i = 0; i < 10; i++) {
	        soma += res[i];
	    }
		
		resto = soma % 11;
	    div = Math.floor(soma / 11);
	    dig2 = validar(resto, div);
	    
	    arr.push(dig2);
	    var str = "";

	    for (var i = 0; i < 11; i++) {
	        str += arr[i].toString();
	    }

	    document.writeln(str);

	    function getRandomInt(min,max)
	    {
	        return Math.floor(Math.random() * (max - min) + min);
	    }

	    function validar(resto, div)
	    {
	        if (resto < 2) {
	            return 0;
	        }

	        return 11 - resto;
	    }
		
	}
	
	exec();
	
}