using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerDif : MonoBehaviour
{
    [SerializeField]
    private GameObject block1;

    public static int l = 20;
    public static int a = 24;

    public static elementInt1[,] ElementsDif = new elementInt1 [l, a]; //requisito pro algoritimo funfar
    public static string GameStateDif; //Stop, Play, GameOver, Win
    

    void Start()
    {
        this.CriarCampo();
        GameControllerDif.GameStateDif = "jogar";
    }

    
    void Update()
    {
         
    }
    private void CriarCampo(){ // cria o campo
        for (int i = 0; i < a; i++){
            for (int j = 0; j < l; j++){
                Instantiate(block1, new Vector3(i, j, 0), Quaternion.identity);
            }
        }
    }
    //exibir as minas quando perder
    public static void MinasEscondidas(){
        foreach (elementInt1 item in ElementsDif){
            if(item.ehmina()){
                item.LoadTexture(0); 
            }
        }

    }
    // descobrir se eh mina ou n segundo a coordenada
    public static bool MinaEm(int x, int y){
    bool flag = false;
        if (x >= 0 && y >=  0 && x < l && y < a){
            flag = (ElementsDif[x, y].ehmina());
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
                
                ElementsDif[x, y].LoadTexture(PorPerto(x, y));
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
        foreach(elementInt1 item in ElementsDif){
            return false;
        }
        return true;
    }
    
}
