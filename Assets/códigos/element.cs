using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class element : MonoBehaviour
{
    [SerializeField]
    private bool mine; // se for mina 0 para nao 1 para sim
    [SerializeField]
    private Sprite[] emptyTextures; // carrega as outras texturas se n for bomba
    [SerializeField]
    private Sprite mineTexture; // carrega a textura da mina
    
    void Start()
    {
        mine = Random.value <= 0.14;
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        GameController.Elements[x, y] = this; // pega os valores e armazena
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
        if (GameController.GameState == "Play")
        {
        if(mine){
            //tela game over// // mostra a mina e caba o game
            this.LoadTexture(0);
            print("Game Over");
            GameController.MinasEscondidas(); // mostra todas as minas
            GameController.GameState = "Game Over";
        } else {
            //proximidade mina
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;
            int b = GameController.PorPerto(x, y);//mostra quantas minas tem por perto
            this.LoadTexture(b);
            GameController.FFvazio(x, y, new bool[GameController.l, GameController.a]);
            if(GameController.cabo()){
            print("voce venceu");
            GameController.GameState = "win";
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
