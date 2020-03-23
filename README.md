# animated-rotary-phone

Please use .gitignore to ignore auto-generated files:  
https://github.com/github/gitignore/blob/master/Unity.gitignore

Use github with version control:
https://github.com/csinn/CSharp-From-Zero-To-Hero/wiki/GitHub-and-how-to-work-with-Open-Source-in-Visual-Studio


Prefer to organize code logically. It will be better.

CameraController

GameManager

Player1Script
Healthbar
Barrel

BulletHell
BulletPool
Projectile

Boss1AI
Boss1Projectile
BossOnProjectileTwo

```cs
public class Example : Monobehaviour
{
  [SerializeField]
  private Transform target;

  public Transform Target
  {
    get {return target;}
    set {return target = value;}
  }
}
```
