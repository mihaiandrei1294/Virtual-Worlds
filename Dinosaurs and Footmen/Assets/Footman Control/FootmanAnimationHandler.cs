using UnityEngine;
using System.Collections;

public class FootmanAnimationHandler : MonoBehaviour {

	private Animator m_anim;

	//some private variable about animation boolean names
	private string idle = "isStanding";
	private string run = "isRunning";
	private string dead = "isDying";
	private string walk = "isWalking";

	// Use this for initialization
	void Start () {
		m_anim = GetComponent<Animator>();
	}
	
	//Functions playing animations
	public void IdleAnim()
	{
		m_anim.SetBool(idle, true);
		m_anim.SetBool(run, false);
		m_anim.SetBool(dead, false);
		m_anim.SetBool(walk, false);
	}
	
	public void RunAnim()
	{
		m_anim.SetBool(idle, false);
		m_anim.SetBool(run, true);
		m_anim.SetBool(dead, false);
		m_anim.SetBool(walk, false);
	}
	
	public void DieAnim()
	{
		m_anim.SetBool(idle, false);
		m_anim.SetBool(run, false);
		m_anim.SetBool(dead, true);
		m_anim.SetBool(walk, false);
	}
	
	public void WalkAnim()
	{
		m_anim.SetBool(idle, false);
		m_anim.SetBool(run, false);
		m_anim.SetBool(dead, false);
		m_anim.SetBool(walk, true);
	}
	
	
	////// Getters //////
	public Animator anim()
	{
		return this.m_anim;
	}
}
