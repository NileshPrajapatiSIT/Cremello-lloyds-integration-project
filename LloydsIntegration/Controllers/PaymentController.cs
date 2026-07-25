using LloydsIntegration.Helpers;
using LloydsIntegration.Models;
using Lloyds.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ChapsModels = Lloyds.Models.Payment.Chaps;
using FasterPaymentModels = Lloyds.Models.Payment.FasterPayment;
using InternationalModels = Lloyds.Models.Payment.International;
using SepaModels = Lloyds.Models.Payment.Sepa;
using TransferModels = Lloyds.Models.Payment.Transfer;

namespace LloydsIntegration.Controllers;

/// <summary>
/// All Payment endpoints (Lloyds Bank Gem API Payment Swaggers_Nov_2024): chaps, faster-payment,
/// international-payment, payment-status, sepa-payment, transfer, and jwks (keystore).
/// Each action keeps the exact route from its source YAML's basePath.
/// </summary>
[ApiController]
[Authorize]
public class PaymentController : ControllerBase
{
    private readonly IChapsPaymentService _chapsPaymentService;
    private readonly IFasterPaymentService _fasterPaymentService;
    private readonly IInternationalPaymentService _internationalPaymentService;
    private readonly IPaymentStatusService _paymentStatusService;
    private readonly ISepaPaymentService _sepaPaymentService;
    private readonly ITransferService _transferService;
    private readonly IJwksService _jwksService;

    public PaymentController(
        IChapsPaymentService chapsPaymentService,
        IFasterPaymentService fasterPaymentService,
        IInternationalPaymentService internationalPaymentService,
        IPaymentStatusService paymentStatusService,
        ISepaPaymentService sepaPaymentService,
        ITransferService transferService,
        IJwksService jwksService)
    {
        _chapsPaymentService = chapsPaymentService;
        _fasterPaymentService = fasterPaymentService;
        _internationalPaymentService = internationalPaymentService;
        _paymentStatusService = paymentStatusService;
        _sepaPaymentService = sepaPaymentService;
        _transferService = transferService;
        _jwksService = jwksService;
    }

    /// <summary>bilateral-chaps-payment-channel-api-v4.0.0.yaml — POST /chaps-payments.</summary>
    [HttpPost("/bilateral-chaps-payment-api/v4/chaps-payments")]
    public async Task<IActionResult> InitiateChapsPayment([FromBody] ChapsModels.PaymentRequest request, CancellationToken cancellationToken)
    {
        var result = await _chapsPaymentService.InitiateChapsPaymentAsync(request, cancellationToken);

        return result.IsSuccess
            ? ApiResponseHelper.Success(result.Data, "Chaps payment initiated.", result.StatusCode)
            : ApiResponseHelper.Error(result.ErrorMessage ?? "Failed to initiate Chaps payment.", result.StatusCode);
    }

    /// <summary>bilateral-faster-payment-channel-api-v4.0.0.yaml — POST /faster-payments.</summary>
    [HttpPost("/bilateral-faster-payment-api/v4/faster-payments")]
    public async Task<IActionResult> InitiateFasterPayment([FromBody] FasterPaymentModels.PaymentRequest request, CancellationToken cancellationToken)
    {
        var result = await _fasterPaymentService.InitiateFasterPaymentAsync(request, cancellationToken);

        return result.IsSuccess
            ? ApiResponseHelper.Success(result.Data, "Faster payment initiated.", result.StatusCode)
            : ApiResponseHelper.Error(result.ErrorMessage ?? "Failed to initiate Faster payment.", result.StatusCode);
    }

    /// <summary>bilateral-international-payment-channel-api-v3.0.0.yaml — POST /international-payments.</summary>
    [HttpPost("/bilateral-international-payment-api/v3/international-payments")]
    [ProducesResponseType(typeof(ApiResponse<InternationalModels.InternationalPaymentResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> InitiateInternationalPayment([FromBody] InternationalModels.PaymentRequest internationalPaymentRequest, CancellationToken cancellationToken)
    {
        var result = await _internationalPaymentService.InitiateInternationalPaymentAsync(internationalPaymentRequest, cancellationToken);

        return result.IsSuccess
            ? ApiResponseHelper.Success(result.Data, "International payment initiated.", result.StatusCode)
            : ApiResponseHelper.Error(result.ErrorMessage ?? "Failed to initiate international payment.", result.StatusCode == 0 ? StatusCodes.Status502BadGateway : result.StatusCode);
    }

    /// <summary>bilateral-payment-status-channel-api-v3.0.0.yaml — GET /payment-status.</summary>
    [HttpGet("/bilateral-payment-status-api/v3/payment-status")]
    public async Task<IActionResult> GetPaymentStatus([FromQuery] string paymentOrderIdentification, CancellationToken cancellationToken)
    {
        var result = await _paymentStatusService.GetPaymentStatusAsync(paymentOrderIdentification, cancellationToken);

        return result.IsSuccess
            ? ApiResponseHelper.Success(result.Data, "Payment status retrieved.", result.StatusCode)
            : ApiResponseHelper.Error(result.ErrorMessage ?? "Failed to retrieve payment status.", result.StatusCode);
    }

    /// <summary>bilateral-sepa-payment-channel-api-v2.0.0.yaml — POST /sepa-payments.</summary>
    [HttpPost("/bilateral-sepa-payment-api/v2/sepa-payments")]
    [ProducesResponseType(typeof(ApiResponse<SepaModels.SepaPaymentResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> InitiateSepaPayment([FromBody] SepaModels.PaymentRequest sepaPaymentRequest, CancellationToken cancellationToken)
    {
        var result = await _sepaPaymentService.InitiateSepaPaymentAsync(sepaPaymentRequest, cancellationToken);

        return result.IsSuccess
            ? ApiResponseHelper.Success(result.Data, "SEPA payment initiated.", result.StatusCode)
            : ApiResponseHelper.Error(result.ErrorMessage ?? "Failed to initiate SEPA payment.", result.StatusCode == 0 ? StatusCodes.Status502BadGateway : result.StatusCode);
    }

    /// <summary>bilateral-transfer-channel-api-v3.0.0.yaml — POST /transfers.</summary>
    [HttpPost("/bilateral-transfer-api/v3/transfers")]
    [ProducesResponseType(typeof(ApiResponse<TransferModels.TransferPaymentResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> InitiateTransfer([FromBody] TransferModels.PaymentRequest transferRequest, CancellationToken cancellationToken)
    {
        var result = await _transferService.InitiateTransferAsync(transferRequest, cancellationToken);

        return result.IsSuccess
            ? ApiResponseHelper.Success(result.Data, "Transfer initiated.", result.StatusCode)
            : ApiResponseHelper.Error(result.ErrorMessage ?? "Failed to initiate transfer.", result.StatusCode == 0 ? StatusCodes.Status502BadGateway : result.StatusCode);
    }

    /// <summary>lbg-group-jwks-api-v1.0.0.yaml — GET /lloydsbanking.jwks.</summary>
    [HttpGet("/keystore/lloydsbanking.jwks")]
    public async Task<IActionResult> GetJwks(CancellationToken cancellationToken)
    {
        var result = await _jwksService.GetJwksAsync(cancellationToken);

        return result.IsSuccess
            ? ApiResponseHelper.Success(result.Data, "JWKS retrieved.", result.StatusCode)
            : ApiResponseHelper.Error(result.ErrorMessage ?? "Failed to retrieve JWKS.", result.StatusCode);
    }
}
