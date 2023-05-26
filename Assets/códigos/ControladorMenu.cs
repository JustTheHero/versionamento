using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ControladorMenu : MonoBehaviour
{
   [SerializeField]
   private GameObject painelmenuinicial;
  
   [SerializeField]
   private GameObject menuDificuldades;
  
   [SerializeField] 
   private GameObject painelopcoes;
   
   [SerializeField]
   private string Dificuldade;
    [SerializeField]
   private string Intermediario;
    [SerializeField]
   private string Dificuldade2;


   public void jogarf(){
    SceneManager.LoadScene(Dificuldade);
   }
   public void jogari(){
    SceneManager.LoadScene(Intermediario);
   }
   public void jogard(){
    SceneManager.LoadScene(Dificuldade2);
   }
   public void abriropces(){
    painelmenuinicial.SetActive(false);
    painelopcoes.SetActive(true);
   }
   public void fecharopcos(){
    painelmenuinicial.SetActive(true);
    painelopcoes.SetActive(false);
   }
   public void escolherDificulade(){
      painelmenuinicial.SetActive(false);
      menuDificuldades.SetActive(true);
   }
   public void sairDificuldads(){
      painelmenuinicial.SetActive(true);
      menuDificuldades.SetActive(false);
   }
   public void sar(){
    Debug.Log("sair do jogo");
    Application.Quit();
   }
}
