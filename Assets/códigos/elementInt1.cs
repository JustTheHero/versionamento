using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementInt1 : MonoBehaviour
{
     [SerializeField]
    private bool mine; // se for mina 0 para nao 1 para sim
    [SerializeField]
    private Sprite[] emptyTextures; // carrega as outras texturas se n for bomba
    [SerializeField]
    private Sprite mineTexture; // carrega a textura da mina
    
    void Start()
    {
        mine = Random.value <= 0.30;
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        GameControllerDif.ElementsDif[x, y] = this; // pega os valores e armazena
    }

    
    void Update()
    {
       
    }
    public bool ehmina(){
        return this.mine;
    }
    public void LoadTexture(int sobraCount){
        if(mine){
            GetComponent<SpriteRenderer>().sprite = mineTexture;   //busca a textura da mina
            
        } else {
            GetComponent<SpriteRenderer>().sprite = emptyTextures[sobraCount]; // busca as outras texturas
        }
    }

    private void OnMouseUpAsButton(){ //reconhecer o clique do mouse
        if (GameControllerDif.GameStateDif == "jogar")
        {
        if(mine){
            //tela game over// // mostra a mina e caba o game
            this.LoadTexture(0);
            print("Game Over");
            GameControllerDif.MinasEscondidas(); // mostra todas as minas
            GameControllerDif.GameStateDif = "perdeu";
        } else {
            //proximidade mina
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;
            int b = GameControllerDif.PorPerto(x, y);//mostra quantas minas tem por perto
            this.LoadTexture(b);
            GameControllerDif.FFvazio(x, y, new bool[GameControllerDif.l, GameControllerDif.a]);
            if(GameControllerDif.cabo()){
            print("voce venceu");
            GameControllerDif.GameStateDif = "ganhou";
            }
            
         }
        }
        }
    
    public bool tampado(){
        bool flag = false;
        if(GetComponent<SpriteRenderer>().sprite.texture.name == "default"){
            flag = true;
        }
            return flag;
    }
    
}
