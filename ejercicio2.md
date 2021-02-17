#Ejercicio2

a)La inconsistencia de los resultados es porque al momento de utilizar la memoria compartida, los hilos no se utiliza de la manera correcta la seccion critica. La memoria compartida se declara en la linea 7 y la seccion critica en la funcion "count" de la linea 31.

b)Para la seccion critica, en mi opinion se podria resolver de una buena manera utilizando mutex, y de esta manera se trabajaria con una variable global