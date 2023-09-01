● ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
 	Pedido - Cliente -> Composición
	Pedido - Cadete -> Agregación
	Cadete - Cadeteria -> Agregación
	
● ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
● Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles privados.

	Clase Cadete
	-- Atributos --
	privado: ListadoPedido
	publico: todos los demas
	-- Metodos --
	Todos publicos

	Clase Pedido
	-- Atributos --
	privado: Cliente
	publico: todos los demas
	-- Metodos --
	Todos publicos

	Clase Cadeteria
	-- Atributos --
	privado: ListadoCadetes
	publico: todos los demas
	-- Metodos --
	Todos publicos

	Clase Cliente
	-- Atributos --

	-- Metodos --
	
● ¿Cómo diseñaría los constructores de cada una de las clases?
● ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?