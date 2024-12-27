using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RunGroupMVC_teddy.Controllers;
using RunGroupMVC_teddy.Interfaces;
using RunGroupMVC_teddy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunGroopWebApp.Test.Controller
{
 public class ClubControllerTests
 {

  //first testing DI
  private ClubController _clubController;
  private IClubRepository _clubRepository;
  private IPhotoService _photoService;
  private IHttpContextAccessor _httpContextAccessor;
  public ClubControllerTests()
  {

   _clubRepository = A.Fake<IClubRepository>();
   _photoService = A.Fake<IPhotoService>();
   _httpContextAccessor = A.Fake<HttpContextAccessor>();
   _clubController = new ClubController(_clubRepository, _photoService, _httpContextAccessor);
  }

  [Fact]
  public void ClubController_Index_ReturnsSuccess()
  {
   //arrange - what do i bring in
   var clubs = A.Fake<IEnumerable<Club>>();
   A.CallTo(() => _clubRepository.GetAll()).Returns(clubs);
   //Act
   var result = _clubController.Index();

   //Assert-Object check actions

   result.Should().BeOfType<Task<IActionResult>>();
  }

  [Fact]
  public void ClubController_Detail_ReturnsSuccess()
  {

   //Arrange
   var id = 1;
   var club = A.Fake<Club>();
   A.CallTo (() => _clubRepository.GetById(id)).Returns(club);
   //Act
   var result = _clubController.Detail(id);
   //Assert
   result.Should().BeOfType<Task<IActionResult>>();                       
  }


 }
}
