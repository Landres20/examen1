#Ejercicio2

a)La inconsistencia de los resultados es porque al momento de utilizar la memoria compartida, los hilos no utilizan de la manera correcta la seccion critica. La memoria compartida se declara en la linea 7 y la seccion critica en la funcion "count" de la linea 31.

b)Para la seccion critica, en mi opinion se podria resolver de una buena manera utilizando mutex, ya que esto mapea la variable, y el resto de los threads solo pueden acceder a ella hasta que este desbloqueada. Debido a esto, cada thread podria accesar a la variable hasta que se le indique que la misma esta desbloqueada.