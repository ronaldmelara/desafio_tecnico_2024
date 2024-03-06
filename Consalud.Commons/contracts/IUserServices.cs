using System;
using CConsalud.Model.Responses;
using Consalud.Model.Requests;

namespace Consalud.Commons.contracts
{
	public interface IUserServices
	{
        AuthResponse CreateUser(AuthRequest request);
        AuthResponse LoginUser(AuthRequest request);

    }
}

