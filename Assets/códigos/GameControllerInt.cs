using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerInt : MonoBehaviour
{
    [SerializeField]
    private GameObject block2;

    public static int l = 16;
    public static int a = 16;
    public static elementInt[,] ElementsInt = new elementInt [l, a]; //requisito pro algoritimo funfar
    public static string GameState; //Stop, Play, GameOver, Win
    

    void Start()
    {
        this.CriarCampo();
        GameControllerInt.GameState = "Play";
    }

    
    void Update()
    {
         
    }
    private void CriarCampo(){ // cria o campo
        for (int i = 0; i < a; i++){
            for (int j = 0; j < l; j++){
                Instantiate(block2, new Vector3(i, j, 0), Quaternion.identity);
            }
        }
    }
    //exibir as minas quando perder
    public static void MinasEscondidas(){
        foreach (elementInt item in ElementsInt){
            if(item.ehmina()){
                item.LoadTexture(0); 
            }
        }

    }
    // descobrir se eh mina ou n segundo a coordenada
    public static bool MinaEm(int x, int y){
    bool flag = false;
        if (x >= 0 && y >=  0 && x < l && y < a){
            flag = (ElementsInt[x, y].ehmina());
        }
    return flag;
    }
    //quantas minas tem por perto
    public static int PorPerto (int x, int y){
        int count = 0;
        if (MinaEm(x, y + 1)) count++; 
        if (MinaEm(x + 1, y + 1)) count++; 
        if (MinaEm(x + 1, y)) count++; 
        if (MinaEm(x + 1, y - 1)) count++; 
        if (MinaEm(x, y - 1)) count++; 
        if (MinaEm(x - 1, y - 1)) count++; 
        if (MinaEm(x - 1, y)) count++; 
        if (MinaEm(x - 1, y + 1)) count++; 
        return count;
    }
    // faz com que todos os espacos sem minas proximas sejam revelados no clique
    public static void FFvazio (int x, int y, bool[,] vistos){
        if(x >= 0 && y >= 0 && x < l && y < a){
            if (vistos[x, y])
                return; // condicao para n rever o mesmo bloco
                
                ElementsInt[x, y].LoadTexture(PorPerto(x, y));
            if(PorPerto(x, y) > 0)
                return;// condicao perto de mina
                vistos[x, y] = true;

            FFvazio(x - 1, y, vistos);
            FFvazio(x + 1, y, vistos);
            FFvazio(x, y - 1, vistos);
            FFvazio(x, y + 1, vistos);// recursividade 

        }
    }
    public static bool cabo(){
        foreach(elementInt item in ElementsInt){
            return false;
        }
        return true;
    }
    
}

