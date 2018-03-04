using UnityEngine;

namespace Es.InkPainter.Sample
{
	[RequireComponent(typeof(Collider), typeof(MeshRenderer))]
	public class CollisionPainter : MonoBehaviour
	{
		[SerializeField]
		private Brush brush = null;

        public void SetBrushColor(Color color){
            brush.Color = color;
        }

		[SerializeField]
		private int wait = 3;

		private int waitCount;

       // ColorManager.ColorList myColor;

		public void Awake()
		{
            //myColor = GetComponent<ColorModule>().MyColor;
            //get la couleur rgb 


			//GetComponent<MeshRenderer>().material.color = brush.Color;
		}

		public void FixedUpdate()
		{
			++waitCount;
		}

		public void OnCollisionStay(Collision collision)
		{
			if(waitCount < wait)
				return;
			waitCount = 0;

			foreach(var p in collision.contacts)
			{
				var canvas = p.otherCollider.GetComponent<InkCanvas>();
				if(canvas != null)
					canvas.Paint(brush, p.point);
			}
		}
	}
}