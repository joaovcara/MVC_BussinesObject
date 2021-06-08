using Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_BussinesObject.Controllers
{
    public class HomeController : Controller
    {
        #region Index
        // GET: Home
        public ActionResult Index()
        {
            //cria instancia da classe bll
            AlunoBll _aluno = new AlunoBll();

            //usando metodo Get alunos e retornando uma lista de alunos
            List<Aluno> lista = _aluno.GetAluno().ToList();

            //passando para a view
            return View(lista);
        }
        #endregion

        #region Insert
        //Get
        public ActionResult Insert()
        {
            return View();
        }
        #endregion

        #region Insert FormCollection
        //[HttpPost]
        //public ActionResult Insert(FormCollection formulario)
        //{
        //    //Nova instancia da classe Aluno
        //    Aluno aluno = new Aluno();

        //    //atribuindo valores do formulário para o objeto
        //    aluno.Nome = formulario["Nome"];
        //    aluno.Email = formulario["Email"];
        //    aluno.Idade = Convert.ToInt32(formulario["Idade"]);
        //    aluno.DataCadastro = Convert.ToDateTime(formulario["DataCadastro"]);
        //    aluno.Sexo = formulario["Sexo"];

        //    //nova instancia da classe alunoBll onde esta a regra de insert
        //    AlunoBll alunoBll = new AlunoBll();

        //    //Usando o metodo Insert
        //    alunoBll.AlunoInsert(aluno);

        //    //redirecionando para a index
        //    return RedirectToAction("Index");
        //}
        #endregion

        #region Insert Objeto Aluno METODO MAIS COMUM      <<<<<-------------<
        [HttpPost]
        public ActionResult Insert(Aluno aluno)
        {

            if (ModelState.IsValid)
            {
                //nova instancia da classe alunoBll onde esta a regra de insert
                AlunoBll alunoBll = new AlunoBll();

                //Usando o metodo Insert
                alunoBll.AlunoInsert(aluno);

                //redirecionando para a index
                return RedirectToAction("Index");
            }

            return View();
            
        }
        #endregion

        #region Insert Sem Parametros (UpdateModel = lança exeption) (tryUpdateMode = não lança exception)
        //[HttpPost]
        //[ActionName("Insert")] //mapeamento a action "Insert" à action "Insert_Post"
        //public ActionResult Insert_Post()  ///metodo sem parametro a assinatura não pode ser repetida pois não identifica como post
        //{

        //    if (ModelState.IsValid)
        //    {
        //        //nova instancia da classe aluno onde esta a regra de insert
        //        Aluno aluno = new Aluno();

        //        //Preenche o objeto com os dados do formulario
        //        UpdateModel(aluno);

        //        //Instancia da classe ALunoBll
        //        AlunoBll alunoBll = new AlunoBll();

        //        //Usando o metodo Insert
        //        alunoBll.AlunoInsert(aluno);

        //        //redirecionando para a index
        //        return RedirectToAction("Index");
        //    }

        //    return View();

        //}
        #endregion

    }
}