var carton = new int [9,3];
var genRandom = new Random();

// lleno el carton de numeros
for (int c = 0; c < 9; c++)
{
    for (int f = 0; f < 3; f++)
    {
        int nuevoNumero = 0;
        bool esNuevo = false;
        while (!esNuevo)
        {
            if (c == 0)
            {
                nuevoNumero = genRandom.Next(1,10);
            } else if (c == 8)
            {
                nuevoNumero = genRandom.Next(80,91);
            } else
            {
                nuevoNumero = genRandom.Next(c*10,c*10+10);
            }


            // busco los repetidos
            esNuevo = true;
            for (int f2 = 0; f2 < 3; f2++)
                {
                if (carton[c,f2] == nuevoNumero)
                    esNuevo = false;
                    break;
                } 
            }
        carton[c, f] = nuevoNumero;
    }
   
}


// ordeno los numeros del carton

for (int c = 0; c < 9; c++)
{
    for (int f = 0; f < 3; f++)
    {
       for (int k = f+1; k < 3; k++)
       {
           if (carton[c,f] > carton[c,k])
           {
               int aux = carton[c,f];
               carton[c,f] = carton[c,k];
               carton[c,k] = aux;
           }
       }
    }
}

//borro los numeros que me sobran
var borrados = 0;

while (borrados < 12)
{
    int filaABorrar = genRandom.Next(0,3);
    int colABorrar = genRandom.Next(0,9);
    
    if (carton[colABorrar,filaABorrar] == 0)
    {
        continue;
    }

    //cuento los ceros por fila 
    var cerosFila = 0;
    for (int c = 0; c < 9; c++)
    {
        if (carton[c,filaABorrar] == 0)
        {
            cerosFila++;
        }       
    }

    //cuento los ceros por columna
    var cerosCol = 0;
    for (int f = 0; f < 3; f++)
    {
        if (carton[colABorrar,f] == 0)
        {
            cerosCol++;
        }
    }

    //cuento cantidad de numeros por columna
    var itemsPorCol = new int [9];

    for (int c = 0; c < 9; c++)
    {
        for (int f = 0; f < 3; f++)
        {
           if (carton[c,f] != 0)
           {
              itemsPorCol[c]++; 
           } 
        }
    }


    //cuento cuantas columnas hay con un solo numero
    var colConUno = 0;
    for (int c = 0; c < 9; c++)
    {
        if (itemsPorCol[c] == 1)
        {
            colConUno++;
        }
    }

    if (cerosFila == 4 || cerosCol == 2)
    {
        continue;
    }

    if (colConUno == 3 && itemsPorCol[colABorrar] !=3)
    {
        continue;
    }
    carton[colABorrar,filaABorrar] = 0;
    borrados++;
}


// Muestro el carton  = aux; 
for (int f = 0; f < 3; f++)
{
    for (int c = 0; c < 9; c++)
    {
        Console.Write($"| {carton[c,f]:00} ");
    }
    Console.WriteLine();

}
